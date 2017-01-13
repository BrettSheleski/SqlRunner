using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlRunner.Core
{
    public enum JobScriptStatus
    {
        Queued,
        Executing,
        Finished,
        Error
    }
}
