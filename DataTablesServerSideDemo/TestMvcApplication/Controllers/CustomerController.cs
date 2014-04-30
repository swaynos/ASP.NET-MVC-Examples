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
            List<string> companies = db.GetCompanies();
            companies.Insert(0, "");
            SearchViewModel viewModel = new SearchViewModel()
            {
                Model = model,
                Companies = new SelectList(companies),
                Results = new List<Customer>() // This will be populated via Ajax
            };
            return View("Search", viewModel);
        }
        [HttpGet]
        public JsonResult AjaxHandler(jQueryDataTableParamModel param)
        {
            int totalCustomersCount, totalFilteredCustomersCount;

            List<Customer> results = db.SearchCustomers(out totalCustomersCount, out totalFilteredCustomersCount, param);

            // jQuery DataTables expected values  http://datatables.net/usage/server-side     
            return Json(new
            {
                iTotalRecords = totalCustomersCount,
                iTotalDisplayRecords = totalFilteredCustomersCount,
                sEcho = param.sEcho,
                aaData = results.Select(t => t.GetDataTableRow()).ToArray()
            }, JsonRequestBehavior.AllowGet);
        }
        
    }
}
