using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ViewEmailMonitoringDaily
    {
        public DateTime? Date { get; set; }
        public string TemplateName { get; set; }
        public int? Issue { get; set; }
        public string IssueDescription { get; set; }
        public int? Count { get; set; }
        public decimal? _ { get; set; }
    }
}
