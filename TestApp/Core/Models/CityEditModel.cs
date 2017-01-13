using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CityEditModel : IModel
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public string CountryName { get; set; }
        public string CountryCode { get; set; }


    }
}
