using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMvcApplication.Helpers;
using TestMvcApplication.Models;

namespace TestMvcApplication.DataAccess
{
    public class AdventureWorksDataAccess : AdventureWorksContext
    {
        public List<Customer> SearchCustomers(out int totalCustomersCount, out int totalFilteredCustomersCount, jQueryDataTableParamModel param)
        {
            // Note: This data access design is not efficient, consider refactoring to a stored procedure before scaling.
            IQueryable<Customer> customers = base.Customers.Where(t => (t.CompanyName.Equals(param.CompanyName) || param.CompanyName.Equals(null))
                && (t.ModifiedDate >= param.LastModifiedDateStart || param.LastModifiedDateStart.Equals(null))
                && (t.ModifiedDate <= param.LastModifiedDateEnd || param.LastModifiedDateEnd.Equals(null))
            );
            totalCustomersCount = customers.Count();
            customers = customers.Where(t =>
                // Master keyword search
                t.CustomerId.ToString().Equals(param.sSearch)
                || t.CompanyName.Contains(param.sSearch)
                || t.EmailAddress.Contains(param.sSearch)
                || t.FirstName.Contains(param.sSearch)
                || t.MiddleName.Contains(param.sSearch)
                || t.LastName.Contains(param.sSearch)
                || t.Suffix.Contains(param.sSearch)
                || t.ModifiedDate.ToString().Contains(param.sSearch)
                || t.Phone.Contains(param.sSearch)
                || t.SalesPerson.Contains(param.sSearch)
                || t.Title.Contains(param.sSearch)
                || param.sSearch == null
            );
            if (param.aaSortingCols.Count() > 0)
            {
                var orderedQuery = (param.aaSortingCols[0][1] > 0) ?
                        customers.OrderBy(HelperMethods.CustomerOrderByHelper(param.aaSortingCols[0])) :
                        customers.OrderByDescending(HelperMethods.CustomerOrderByHelper(param.aaSortingCols[0]));

                for (int i = 1; i < param.aaSortingCols.Count(); i++)
                {
                    orderedQuery = (param.aaSortingCols[i][1] > 0) ?
                        orderedQuery.ThenBy(HelperMethods.CustomerOrderByHelper(param.aaSortingCols[0])) :
                        orderedQuery.ThenByDescending(HelperMethods.CustomerOrderByHelper(param.aaSortingCols[0]));
                }
                customers = orderedQuery.AsQueryable();
                totalFilteredCustomersCount = customers.Count(); 
            }
            else
            {
                totalFilteredCustomersCount = totalCustomersCount;
            }

            return customers.Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList(); 
        }
        public List<string> GetCompanies()
        {
            return base.Customers.Select(t => t.CompanyName).Distinct().ToList();
        }
    }
}