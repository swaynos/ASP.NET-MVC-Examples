using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMvcApplication.DataAccess;
using TestMvcApplication.Models;
using TestMvcApplication.ViewModels;

namespace TestMvcApplication.Controllers
{
    public class CustomerController : Controller
    {
        private AdventureWorksDataAccess db = new AdventureWorksDataAccess();

        [HttpGet]
        public ActionResult Search(SearchModel model)
        {
            SearchViewModel viewModel = new SearchViewModel()
            {
                Model = model,
                Companies = new SelectList(db.GetCompanies()),
                Results = new List<Customer>() // This will be populated via Ajax
            };
            return View("Search", viewModel);
        }
        [HttpGet]
        public JsonResult AjaxHandler(jQueryDataTableParamModel param)
        {
            int totalLogsCount;

            List<Customer> results = db.SearchCustomers(out totalLogsCount, param);

            // jQuery DataTables expected values  http://datatables.net/usage/server-side     
            return Json(new
            {
                iTotalRecords = totalLogsCount,
                iTotalDisplayRecords = results.Count,
                sEcho = param.sEcho,
                aaData = results.Select(t => t.GetDataTableRow()).ToArray()
            }, JsonRequestBehavior.AllowGet);
        }
        
    }
}
