using System;
using System.Windows.Input;

namespace MyMDB.Core.ViewModel
{
    public class ActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action _action;
        public string Message { get; set; }

        public ActionCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
            Message = parameter as string;
        }
    }
}