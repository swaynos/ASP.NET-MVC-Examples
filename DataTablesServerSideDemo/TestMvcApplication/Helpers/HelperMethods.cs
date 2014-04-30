using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMvcApplication.Models;

namespace TestMvcApplication.Helpers
{
    public class HelperMethods
    {
        public static Func<Customer, object> CustomerOrderByHelper(int[] array)
        {
            if (array.Count() != 2)
            {
                throw new ArgumentException();
            }
            switch (array[0])
            {
                case 0:
                    return new Func<Customer, object>(t => t.CustomerId);
                case 1:
                    return new Func<Customer, object>(t => t.Title);
                case 2:
                    return new Func<Customer, object>(t => t.Name);
                case 3:
                    return new Func<Customer, object>(t => t.CompanyName);
                case 4:
                    return new Func<Customer, object>(t => t.SalesPerson);
                case 5:
                    return new Func<Customer, object>(t => t.Phone);
                case 6:
                    return new Func<Customer, object>(t => t.EmailAddress);
                case 7:
                    return new Func<Customer, object>(t => t.ModifiedDate);
                default:
                    throw new ArgumentException();
            }
        }
    }
}