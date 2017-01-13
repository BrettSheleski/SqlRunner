using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SqlRunner.Core;

namespace SqlRunner.UWP
{
    public class Job : SqlRunner.Core.IJob, INotifyPropertyChanged
    {
        private double _completionPercent;
        private JobStatus _status;

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

        public ObservableCollection<IJobScript> Scripts { get; } = new ObservableCollection<IJobScript>();

        IList<IJobScript> IJob.Scripts
        {
            get
            {
                return this.Scripts;
            }
        }

        JobStatus IJob.Status
        {
            get
            {
                return this.Status;
            }
        }

        public JobStatus Status
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Execute(JobOptions options)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteAsync(JobOptions options, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}
