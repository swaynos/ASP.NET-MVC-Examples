using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestMvcApplication.Models
{
public class SearchModel
{
    /// <summary>
    /// Start date of filtering results
    /// </summary>
    [DisplayName("Start Date")]
    public DateTime? LastModifiedDateStart { get; set; }
    /// <summary>
    /// End date of filtering results
    /// </summary>
    [DisplayName("End Date")]
    public DateTime? LastModifiedDateEnd { get; set; }
    /// <summary>
    /// CompanyName that we would like to filter by
    /// </summary>
    [DisplayName("Company Name")]
    public string CompanyName { get; set; }
}
}