using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Services;

namespace Services.City
{
    public class CityListService : Core.Services.ICityListService
    {
        public Task<ServiceResponse<CityListModel>> GetAsync()
        {
            throw new NotImplementedException();   
        }

        public Task SaveAsync(CityListModel model)
        {
            throw new NotImplementedException();
        }
    }
}
