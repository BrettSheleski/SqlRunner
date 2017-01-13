using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Models;

namespace TestApp.geo.City
{
    public class EditViewModel : ViewModel<Core.Models.CityEditModel>
    {
        public EditViewModel(CityEditModel model) : base(model)
        {
        }
    }
}