using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlRunner.Core
{
    public enum JobStatus
    {
        NotStarted,
        Executing,
        Finished,
        Error
    }
}
