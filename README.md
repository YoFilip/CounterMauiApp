# Counter MAUI App

**Repository:** [Counter MAUI App](https://github.com/YoFilip/CounterMauiApp)

## Project Description
The Counter MAUI App is a cross-platform application built using .NET MAUI that allows users to create, edit, and manage counters. Each counter can have a title, a numeric value, and a color. The app provides a user-friendly interface for interacting with the counters, including incrementing, decrementing, resetting, and deleting them. 

## Features
- Add, edit, and delete counters.
- Increment and decrement counter values.
- Reset counter values to their initial state.
- Color customization for counters.
- Persistent storage using SQLite.

## Technologies
- **.NET MAUI**: A framework for building cross-platform applications.
- **SQLite**: A lightweight database for storing counter data.
- **C#**: The programming language used for application logic.

## Installation and Configuration
To run the Counter MAUI App, ensure you have the following prerequisites installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with .NET MAUI workload installed.

### Steps to Run the Application
1. Clone the repository:
   
   ```bash
   git clone https://github.com/YourGitHubUsername/CounterMAUIApp.git

2. Navigate to the project directory:
   
   ```bash
   cd CounterMAUIApp
3. Restore the dependencies:
   
   ```bash
   dotnet restore
4. Run the application:
   
   ```bash
   dotnet run

5. The application will launch in your default emulator or device.

## Usage
- Click on the "Add Counter" button to create a new counter.
- Fill in the title and value, select a color, and click "Add Counter" to save.
- Use the "+" and "-" buttons to adjust the counter value.
- Click "Edit" to modify an existing counter.
- Click "Delete" to remove a counter.
- Click "Reset" to set the counter back to its initial value.

## Contributing
Contributions are welcome! Please open an issue or submit a pull request for any enhancements or bug fixes.

## License
This project is licensed under the MIT License - see the LICENSE file for details.
- [Microsoft MAUI Documentation](https://docs.microsoft.com/en-us/dotnet/maui/)
- [SQLite Documentation](https://www.sqlite.org/docs.html)
