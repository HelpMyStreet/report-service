using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ViewMonitoringTimestamps
    {
        public string Activity { get; set; }
        public int RunId { get; set; }
        public string Trigger { get; set; }
        public DateTime? Timestamp { get; set; }
        public int? SecsElapsed { get; set; }
        public int? RowsAffected { get; set; }
        public DateTime? ProcessedTo { get; set; }
    }
}
