using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlRunner
{
    public interface IJobFactory
    {
        SqlRunner.Core.IJob CreateJob(IEnumerable<SqlRunner.Core.IJobScript> scripts);
    }
}
