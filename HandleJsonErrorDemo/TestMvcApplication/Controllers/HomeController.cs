using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMvcApplication.Helpers;

namespace TestMvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private static int count = 0; // Note: In any real application this is a bad way to implement a counter

        public ActionResult Index()
        {
            return View();
        }

        [HandleJsonErrorAttribute]
        public JsonResult GiveMeJson(bool isError)
        {
            if (isError)
            {
                throw new Exception("This is a sample error.");
            }
            return Json(new 
            {
                Count = count++,
                Foo = "bar",
                Bar = "foo"
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
