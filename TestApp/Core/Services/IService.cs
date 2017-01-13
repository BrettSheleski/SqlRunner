using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    public interface IService
    {
        
    }

    public interface IModelService<T> : IService
    {
        Task SaveAsync(T model);
    }

    public interface IService<T, TGet> : IModelService<T>
        where T : IModel 
        where TGet : ServiceGetRequest
    {
        Task<ServiceResponse<T>> GetAsync(TGet parameters);
    }

    public interface IService<T> : IModelService<T> where T : IModel
    {
        Task<ServiceResponse<T>> GetAsync();
    }

    public class ServiceGetRequest
    {
    }
}
