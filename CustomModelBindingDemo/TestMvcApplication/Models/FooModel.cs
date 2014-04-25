using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestMvcApplication.ModelBinders.Attributes;

namespace TestMvcApplication.Models
{
    [FooModelBinderAttribute]
    public class FooModel
    {
        // ToDo: Display formatting on date
        [DisplayName("Travel Reason")]
        [Required]
        public string TripName { get; set; }

        [DisplayName("Starting Date of Travel")]
        [Required]
        public DateTime TravelStartDate { get; set; }

        [DisplayName("Ending Date of Travel")]
        [Required]
        public DateTime TravelEndDate { get; set; }

        [DisplayName("Wonder Being Visited")]
        [Required]
        public Wonder Wonder { get; set; }
    }
}