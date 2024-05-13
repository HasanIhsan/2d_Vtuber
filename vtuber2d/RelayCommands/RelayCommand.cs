using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace vtuber2d.RelayCommands
{
    public class RelayCommand: ICommand
    {
        private readonly Action _execute; // Action to execute when the command is invoked
        private readonly Func<bool> _canExecute; // Function to determine if the command can be executed

        // Constructor for RelayCommand
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            // Assign the execute action to the private field _execute
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));

            // Assign the canExecute function to the private field _canExecute
            _canExecute = canExecute;
        }

        // Event that is raised when the command's ability to execute changes
        public event EventHandler? CanExecuteChanged
        {
            // Subscribe a handler to the CommandManager's RequerySuggested event
            add { CommandManager.RequerySuggested += value; }

            // Unsubscribe the handler from the CommandManager's RequerySuggested event
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Determines if the command can execute in its current state
        public bool CanExecute(object parameter)
        {
            // If _canExecute is null, or if the _canExecute function returns true, the command can execute; otherwise, it cannot
            return _canExecute == null || _canExecute();
        }

        // Executes the command
        public void Execute(object parameter)
        {
            // Execute the action stored in _execute
            _execute();
        }
    }
}
