using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    public class ServiceResponse<T> where T : IModel
    {
        public ServiceResponse(ServiceRequestStatus status, T result)
        {
            this.Result = result;
            this.Status = status;
        }

        public ServiceRequestStatus Status { get; }
        public T Result { get; }
    }
}
