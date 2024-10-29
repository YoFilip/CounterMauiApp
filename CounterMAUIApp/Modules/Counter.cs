using SQLite;
using System.ComponentModel;

namespace CounterMAUIApp
{
    [Table("Note")]
    public class Counter : INotifyPropertyChanged
    {
        private long _value;
        private string _color;

        [PrimaryKey] // Mark the id property as the primary key
        [AutoIncrement] // Automatically increment the id
        [Column("id")] // Add the id column
        public int Id { get; set; }

        [Column("title")] // Add the title column
        public string Title { get; set; }

        [Column("value")] // Add the value column
        public long Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged(nameof(Value)); // Notify the UI that the value property has changed
                }
            }
        }

        [Column("initial_value")] // Add the initial_value column
        public long InitialValue { get; set; }

        [Column("color")] // Add the color column
        public string Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged(nameof(Color)); // Notify the UI that the color property has changed
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged; 

        protected virtual void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // Raise the PropertyChanged event
        }
    }
}
