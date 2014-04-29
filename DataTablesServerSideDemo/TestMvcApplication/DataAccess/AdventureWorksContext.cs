using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestMvcApplication.Models;

namespace TestMvcApplication.DataAccess
{
    public class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext()
            : base("name=TestMvcApplication.Properties.Settings.AdventureWorksContext")
        {
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer", "SalesLT");
        } 
    }
}