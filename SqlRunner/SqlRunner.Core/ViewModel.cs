using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SqlRunner.Core
{
    public abstract class ViewModel : INotifyPropertyChanged
    {

        protected DelegateCommand CreateCommand(Action action)
        {
            return new DelegateCommand(action); 
        }
        
        protected DelegateCommand CreateAsyncCommand(Func<Task> action)
        {
            return new DelegateCommand(async () => await action());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
