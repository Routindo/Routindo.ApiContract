using System;
using System.Windows.Input;

namespace Routindo.Contract.UI
{
    public class RelayCommand : ICommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute; 

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        { 
            _canExecute = canExecute;
            _execute = execute; 
        }

        public RelayCommand(Action execute, Func<bool> canExecute) : 
            this(o => { execute(); }, o => canExecute())
        {

        }

        public RelayCommand(Action execute) : this(execute, () => true) { }

        public RelayCommand(Action<object> execute) : this(execute, o => true)
        {
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}