using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SqlRunner.Core
{
    public  class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

     
        protected virtual void OnCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute;
        }

        void ICommand.Execute(object parameter)
        {
            this.Execute();
        }

        private bool _canExecute = true;

        public DelegateCommand(Action action)
        {
            this.Action = action;
        }

        public bool CanExecute
        {
            get
            {
                return _canExecute;
            }

            set
            {
                _canExecute = value;
                OnCanExecuteChanged();
            }
        }

        public Action Action { get; }

        public void Execute()
        {
            this.Action?.Invoke();
        }
    }
}