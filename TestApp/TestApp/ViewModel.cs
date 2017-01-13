using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Core.Models;
using Core.Services;

namespace TestApp
{
    public interface IViewModel<T> where T : IModel
    {
        T Model { get; }

        Task SaveAsync(IModelService<T> service);
    }

    public abstract class ViewModel
    {
        public static Task CompletedTask { get; } = Task.FromResult<object>(null);
    }

    public class ViewModel<T> : ViewModel, IViewModel<T> where T : IModel
    {
        public T Model { get; set; }

        public async Task SaveAsync(IModelService<T> service)
        {
            await service.SaveAsync(Model);
        }
    }
}