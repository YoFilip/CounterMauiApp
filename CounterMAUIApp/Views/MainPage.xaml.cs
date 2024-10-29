using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace CounterMAUIApp
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private int _editNoteId;
        private string _selectedColor;

        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listView.ItemsSource = await _dbService.GetNote()); // Load the notes from the database
        }

        private void AddCounterButton_Clicked(object sender, EventArgs e)
        {
            addCounterButton.IsVisible = false;
            counterForm.IsVisible = true;
            titleEntryField.Text = string.Empty;
            valueEntryField.Text = string.Empty;
            saveButton.Text = "Add Counter"; 
            _editNoteId = 0;
            _selectedColor = "#1E201E"; // Default color for frame
            valueEntryField.IsVisible = true;
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            addCounterButton.IsVisible = true;
            counterForm.IsVisible = false;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleEntryField.Text))
            {
                await DisplayAlert("Invalid Input", "Please enter a title for the counter.", "OK");
                return;
            }

            if (long.TryParse(valueEntryField.Text, out long value))
            {
                Counter note;
                if (_editNoteId == 0)
                {
                    note = new Counter
                    {
                        Title = titleEntryField.Text,
                        Value = value,
                        InitialValue = value,
                        Color = _selectedColor
                    };
                    await _dbService.Create(note);
                }
                else
                {
                    note = await _dbService.GetById(_editNoteId);
                    note.Title = titleEntryField.Text;
                    note.Value = value;
                    note.Color = _selectedColor;
                    await _dbService.Update(note);
                }

                listView.ItemsSource = await _dbService.GetNote(); // Refresh the list view
                CancelButton_Clicked(sender, e); // Hide the form after saving
            }
            else
            {
                /*
                * TODO: style the alert to make it look better.
                * https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pop-ups?view=net-maui-8.0
                * https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/popup
                */

                await DisplayAlert("Invalid Input", "Please enter a valid number for the value.", "OK");
            }
        }

        private async void IncreaseValue_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var note = button.BindingContext as Counter; // Get the note object from the button BindingContext

            if (note.Value < long.MaxValue) // check if the value is less than the maximum limit
            {
                note.Value++;
                await _dbService.Update(note);
                listView.ItemsSource = await _dbService.GetNote(); // Refresh the list view
            }
            else
            {
                /*
                * TODO: style the alert to make it look better.
                * https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pop-ups?view=net-maui-8.0
                * https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/popup
                */
                await DisplayAlert("Limit Reached", "The value cannot exceed the maximum limit of a long integer.", "OK");
            }
        }

        private async void DecreaseValue_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var note = button.BindingContext as Counter;

            if (note.Value > long.MinValue) // Check if the value is greater than the minimum limit
            {
                note.Value--;
                await _dbService.Update(note);
                listView.ItemsSource = await _dbService.GetNote(); // Refresh the list view
            }
            else
            {
                /*
                * TODO: style the alert to make it look better.
                * https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pop-ups?view=net-maui-8.0
                * https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/popup
                */
                await DisplayAlert("Limit Reached", "The value cannot be less than the minimum limit of a long integer.", "OK");
            }
        }

        private void EditNote_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var note = button.BindingContext as Counter;
            _editNoteId = note.Id;
            titleEntryField.Text = note.Title;
            valueEntryField.Text = note.Value.ToString(); // Set the value to the current value
            _selectedColor = note.Color;
            addCounterButton.IsVisible = false;
            counterForm.IsVisible = true;
            saveButton.Text = "Save Counter";
            valueEntryField.IsVisible = false; 
        }

        private async void DeleteNote_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var note = button.BindingContext as Counter;
            await _dbService.Delete(note);
            listView.ItemsSource = await _dbService.GetNote();
        }

        private async void ResetValue_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var note = button.BindingContext as Counter;
            note.Value = note.InitialValue; // Reset value to initial value
            await _dbService.Update(note);
            listView.ItemsSource = await _dbService.GetNote();
        }

        private void ColorButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            _selectedColor = button.CommandParameter.ToString(); // Get the color from the button CommandParameter
        }
    }
}
