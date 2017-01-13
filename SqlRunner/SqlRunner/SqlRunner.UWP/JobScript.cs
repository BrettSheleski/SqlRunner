using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SqlRunner.Core;

namespace SqlRunner.UWP
{
    public class JobScript : SqlRunner.Core.IJobScript, INotifyPropertyChanged
    {



        public JobScript(string filePath)
        {
            this.FilePath = filePath;
            this.Name = Path.GetFileName(filePath);
        }

        private double _completionPercent = 0;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double CompletionPercent
        {
            get
            {
                return _completionPercent;
            }
            set
            {
                _completionPercent = value;
                OnPropertyChanged();
            }
        }

        public string FilePath { get; }

        public string Name { get; }

        public JobScriptStatus Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        private JobScriptStatus _status;
        

        public Stream GetStream()
        {
            return new System.IO.FileStream(this.FilePath, FileMode.Open);
        }
    }
}
