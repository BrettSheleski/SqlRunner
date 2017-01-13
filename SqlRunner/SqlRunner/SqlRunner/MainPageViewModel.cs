using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlRunner.Core;
using Xamarin.Forms;

namespace SqlRunner
{
    public class MainPageViewModel : ViewModel
    {
        public MainPageViewModel()
        {
            this.SelectFilesCommand = CreateAsyncCommand(SelectFilesAsync);
            this.StartCommand = CreateAsyncCommand(StartAsync);
            this.StopCommand = CreateAsyncCommand(StopAsync);
            this.ClearScriptsCommand = CreateAsyncCommand(ClearScriptsAsync);
        }

        private Task ClearScriptsAsync()
        {
            this.Scripts.Clear();

            return CompletedTask;
        }

        private Task StopAsync()
        {
            return Task.FromResult<object>(null);
        }

        private Task StartAsync()
        {
            throw new NotImplementedException();
        }

        private async Task SelectFilesAsync()
        {
            var selector = DependencyService.Get<IJobScriptSelector>();

            var scripts = await selector.GetScriptsAsync();

            foreach (var script in scripts)
            {
                this.Scripts.Add(new ScriptViewModel(script));
            }

        }

        public ObservableCollection<ScriptViewModel> Scripts { get; } = new ObservableCollection<ScriptViewModel>();
        public Command SelectFilesCommand { get; }
        public Command StopCommand { get; }
        public Command StartCommand { get; }
        public Command ClearScriptsCommand { get; private set; }

        public class ScriptViewModel : ViewModel
        {
            public ScriptViewModel(IJobScript script)
            {
                this.Script = script;
            }

            public IJobScript Script { get; }
        }
    }
}
