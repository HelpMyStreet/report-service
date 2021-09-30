using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RequestJob
    {
        public int JobId { get; set; }
        public int? RequestId { get; set; }
        public int? JobsOnRequest { get; set; }
        public int? ReferringGroupId { get; set; }
        public string ReferringGroup { get; set; }
        public string Activity { get; set; }
        public string RequestType { get; set; }
        public DateTime? DateDue { get; set; }
        public string DueDateType { get; set; }
        public DateTime? DateRequested { get; set; }
        public string JobStatus { get; set; }
        public int? VolunteerUserId { get; set; }
        public string ClientRef { get; set; }
        public string Postcode { get; set; }
        public int? CreatedByUserId { get; set; }
        public string RequestorType { get; set; }
        public bool? Archive { get; set; }
        public bool? SuppressRecipientPersonalDetail { get; set; }
        public bool? MultiVolunteer { get; set; }
        public bool? Repeat { get; set; }
        public int? EmailRecipients { get; set; }
        public int? DeliveredEmails { get; set; }
        public int? OpenedEmails { get; set; }
        public int? ClickedEmails { get; set; }
    }
}
