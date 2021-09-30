using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RequestRequest
    {
        public int RequestId { get; set; }
        public int? JobsOnRequest { get; set; }
        public string Postcode { get; set; }
        public int? ReferringGroupId { get; set; }
        public string ReferringGroup { get; set; }
        public string RequestType { get; set; }
        public DateTime? DateRequested { get; set; }
        public int? EmailRecipients { get; set; }
        public int? CreatedByUserId { get; set; }
        public string RequestorType { get; set; }
        public string OrganisationName { get; set; }
        public int? PersonIdRequester { get; set; }
        public int? PersonIdRecipient { get; set; }
        public string Source { get; set; }
        public bool? Archive { get; set; }
        public bool? SuppressRecipientPersonalDetail { get; set; }
        public bool? Repeat { get; set; }
        public bool? MultiVolunteer { get; set; }
    }
}
