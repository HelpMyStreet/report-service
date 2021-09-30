using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class MonitoringTimestamps
    {
        public string Activity { get; set; }
        public int RunId { get; set; }
        public string Trigger { get; set; }
        public bool Start { get; set; }
        public DateTime? Timestamp { get; set; }
        public int? RowsAffected { get; set; }
        public DateTime? ProcessedTo { get; set; }
    }
}
