using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlRunner.Core;

namespace SqlRunner.UWP
{
    class JobFactory : SqlRunner.IJobFactory
    {
        public IJob CreateJob(IEnumerable<IJobScript> scripts)
        {

            var job = new Job();

            foreach(var script in scripts)
            {
                job.Scripts.Add(script);
            }

            return job;
        }
    }
}
