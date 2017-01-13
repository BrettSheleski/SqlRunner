using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SqlRunner
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public static Task CompletedTask { get; } = Task.FromResult<object>(null);

        protected static Command CreateCommand(Action action)
        {
            return new Command(action);
        }

        protected static Command CreateAsyncCommand(Func<Task> action)
        {
            return new Command(async () => await action());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
