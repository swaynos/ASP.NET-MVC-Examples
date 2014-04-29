using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMvcApplication.Models;

namespace TestMvcApplication.DataAccess
{
    public class AdventureWorksDataAccess : AdventureWorksContext
    {
        public List<Customer> SearchCustomers(out int totalLogsCount, jQueryDataTableParamModel param)
        {
            // Note: This design is pretty bad, it will require two seperate transactions to the database to get all of the information needed.
            var customers = base.Customers.Where(t => (t.CompanyName.Equals(param.CompanyName) || param.CompanyName.Equals(null))
                && (t.ModifiedDate >= param.LastModifiedDateStart || param.LastModifiedDateStart.Equals(null))
                && (t.ModifiedDate <= param.LastModifiedDateEnd || param.LastModifiedDateEnd.Equals(null)));

            totalLogsCount = customers.Count(); // transaction 1

            // ToDo: Fix this
            //if (param.aaSortingCols.Count() > 0)
            //{
            //    var orderedQuery = (sortingCols[0][1] > 0) ?
            //        query.OrderBy(HelperMethods.EntryLogOrderByHelper(sortingCols[0])) :
            //        query.OrderByDescending(HelperMethods.EntryLogOrderByHelper(sortingCols[0]));

            //    for (int i = 1; i < sortingCols.Count(); i++)
            //    {
            //        orderedQuery = (sortingCols[i][1] > 0) ?
            //            orderedQuery.ThenBy(HelperMethods.EntryLogOrderByHelper(sortingCols[0])) :
            //            orderedQuery.ThenByDescending(HelperMethods.EntryLogOrderByHelper(sortingCols[0]));
            //    }
            //    query = orderedQuery.AsQueryable();
            //}
            //else
            //{
            //    query = query.OrderBy(t => t.Id);
            //}

            return customers.ToList();
        }
        public List<string> GetCompanies()
        {
            return base.Customers.Select(t => t.CompanyName).Distinct().ToList();
        }
    }
}