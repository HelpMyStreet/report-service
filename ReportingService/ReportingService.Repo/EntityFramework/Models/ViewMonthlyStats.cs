using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ViewMonthlyStats
    {
        public string TimePeriod { get; set; }
        public DateTime Timestamp { get; set; }
        public string GroupName { get; set; }
        public string Subgroup { get; set; }
        public int? Members { get; set; }
        public int? Admins { get; set; }
        public int? ActiveVols { get; set; }
        public int? NonMemberVols { get; set; }
        public int? YotiIds { get; set; }
        public int? OtherCredentials { get; set; }
        public int? Requests { get; set; }
        public int? Jobs { get; set; }
        public string JobsCancelled { get; set; }
        public string JobsCompleted { get; set; }
        public string JobsOverdue { get; set; }
        public string TopActivities { get; set; }
    }
}
