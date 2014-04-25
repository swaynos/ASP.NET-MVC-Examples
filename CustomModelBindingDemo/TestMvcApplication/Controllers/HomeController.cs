using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using TestMvcApplication.Models;

namespace TestMvcApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {   
            // Lets create a SelectList of Wonders and put it in the ViewBag for the view to use.
            ViewBag.Wonders = GetWonderSelectList();

            return View("Index");
        }
        [HttpPost]
        public ActionResult Index(FooModel model)
        {
            if (ModelState.IsValid)
            {
                // Do something with our model here
                return View("Success", model);
            }
            ViewBag.Wonders = GetWonderSelectList(model.Wonder);
            return View("Index", model);
        }

        private SelectList GetWonderSelectList(Wonder selectedValue = null)
        {
            // Some sample data to display as a drop down on the view.
            List<Wonder> wonders = DataAccess.DummyDataAccess.GetWonders();
            if (selectedValue == null)
            {
                return new SelectList(wonders, "Id", "Name", null);
            }
            else
            {
                return new SelectList(wonders, "Id", "Name", wonders.Single(t => t.Id.Equals(selectedValue.Id)));
            }
        }
    }
}
