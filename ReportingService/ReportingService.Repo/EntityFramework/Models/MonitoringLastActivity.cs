using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class MonitoringLastActivity
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int? GroupCount { get; set; }
        public DateTime? LastActiveDate { get; set; }
        public double? PercentEverActive { get; set; }
        public double? PercentActiveWithinLast30Days { get; set; }
    }
}
