using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SqlRunner.Core
{
    public interface IJob
    {
        IList<IJobScript> Scripts { get; }

        JobStatus Status { get; }

        void Execute(JobOptions options);
        Task ExecuteAsync(JobOptions options, CancellationToken cancellationToken);

        double CompletionPercent { get; }
    }
}
