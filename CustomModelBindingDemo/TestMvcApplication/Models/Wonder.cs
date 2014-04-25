using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMvcApplication.Models
{
    public class Wonder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Location { get; set; }
    }
}