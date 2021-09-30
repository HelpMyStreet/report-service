using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ViewJobStatusTimestamps
    {
        public int JobId { get; set; }
        public int? RequestId { get; set; }
        public byte? SupportActivityId { get; set; }
        public byte? JobStatusId { get; set; }
        public int? VolunteerUserId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
