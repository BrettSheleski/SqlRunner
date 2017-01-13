using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestApp.geo.City
{
    public class CitiesApiController : System.Web.Http.ApiController
    {
        public CitiesApiController(TestApp.brett_dataEntities db)
        {
            this.Database = db;
        }

        public brett_dataEntities Database { get; }

        [HttpGet]
        public IndexModel Index()
        {
            return new IndexModel
            {
                Cities = this.Database.Cities1.OrderBy(x => x.Name).Skip(0).Take(100)
            };
        }
    }
}
