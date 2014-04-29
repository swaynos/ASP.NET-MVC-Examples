using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMvcApplication.Models;

namespace TestMvcApplication.ViewModels
{
    public class SearchViewModel
    {
        public SearchModel Model { get; set; }
        public SelectList Companies { get; set; }
        public List<Customer> Results { get; set; }
    }
}