using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using TestMvcApplication.Models;

namespace TestMvcApplication.DataAccess
{
    public class DummyDataAccess
    {
        public static List<Wonder> GetWonders()
        {
            // Load some dummy data from XML
            string path = HttpContext.Current.Server.MapPath("~/App_Data/DummyData.xml");
            XElement xml = XElement.Load(path);
            List<Wonder> wonders = xml.Elements().Select(t => new Wonder()
            {
                Id = System.Convert.ToInt32(t.Element("Id").Value),
                Name = t.Element("Name").Value,
                DateStarted = System.Convert.ToDateTime(t.Element("DateStarted").Value),
                DateFinished = System.Convert.ToDateTime(t.Element("DateFinished").Value),
                Location = t.Element("Location").Value
            }).ToList();
            return wonders;
        }
    }
}