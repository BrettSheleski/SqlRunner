using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApp.geo.City
{
    public class CitiesController : Controller
    {
        public CitiesController(CitiesApiController apiController, brett_dataEntities db)
        {
            this.Api = apiController;
            this.Database = db;
        }

        public CitiesApiController Api { get; }
        public brett_dataEntities Database { get; }


        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            TestApp.City city = this.Database.Cities1.Where(x => x.Id == id).FirstOrDefault();

            if (city == null)
                return HttpNotFound();

            EditViewModel viewModel = new City.EditViewModel
            {
                City = city
            };

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Edit(EditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Save();
            }

            return RedirectToAction("Edit", "City");
        }
    }
}