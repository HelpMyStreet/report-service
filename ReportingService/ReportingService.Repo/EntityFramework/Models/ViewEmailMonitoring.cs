using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ViewEmailMonitoring
    {
        public string TemplateName { get; set; }
        public int? Issue { get; set; }
        public string IssueDescription { get; set; }
        public int? CountLast30Days { get; set; }
        public decimal? Last30Days { get; set; }
        public int? CountPrevious30Days { get; set; }
        public decimal? Previous30Days { get; set; }
    }
}
