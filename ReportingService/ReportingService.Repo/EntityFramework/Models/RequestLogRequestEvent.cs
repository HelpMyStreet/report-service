using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RequestLogRequestEvent
    {
        public int RequestId { get; set; }
        public string ReferringGroup { get; set; }
        public DateTime EventDate { get; set; }
        public string RequestEvent { get; set; }
        public int? JobId { get; set; }
        public int? UserId { get; set; }
        public string VolunteerJobStatus { get; set; }
    }
}
