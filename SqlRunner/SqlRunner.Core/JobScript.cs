using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlRunner.Core
{
    public interface IJobScript
    {
        string Name { get;  }

        System.IO.Stream GetStream();

        JobScriptStatus Status { get; }

        double CompletionPercent { get; }
    }
}
