using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlRunner
{
    public interface IJobScriptSelector
    {
        Task<IEnumerable<SqlRunner.Core.IJobScript>> GetScriptsAsync();
    }
}
