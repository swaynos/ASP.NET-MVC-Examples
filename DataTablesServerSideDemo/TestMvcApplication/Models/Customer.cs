using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestMvcApplication.Models
{
    public class Customer
    {
        [DisplayName("Id")]
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [DisplayName("Sales Person")]
        public string SalesPerson { get; set; }
        public string Phone { get; set; }
        [DisplayName("Email")]
        public string EmailAddress { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name
        {
            get
            {
                string name = FirstName;
                if (!String.IsNullOrWhiteSpace(MiddleName))
                {
                    name += " " + MiddleName;
                }
                if (!String.IsNullOrWhiteSpace(LastName))
                {
                    name += " " + LastName;
                }
                if (!String.IsNullOrWhiteSpace(Suffix))
                {
                    name += " " + Suffix;
                }
                return name;
            }
        }
        public string[] GetDataTableRow()
        {
            // ToDO: Finish and clean this up. 
            return new string[] 
            {
                CustomerId.ToString(), 
                Title,
                Name,
                CompanyName,
                SalesPerson,
                Phone,
                EmailAddress,
                ModifiedDate.ToShortDateString()
            };
        }
    }
}