using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class Request1
    {
        public int Id { get; set; }
        public string PostCode { get; set; }
        public DateTime? DateRequested { get; set; }
        public bool IsFulfillable { get; set; }
        public bool? CommunicationSent { get; set; }
        public byte? FulfillableStatus { get; set; }
        public bool? ForRequestor { get; set; }
        public string OtherDetails { get; set; }
        public int? PersonIdRecipient { get; set; }
        public int? PersonIdRequester { get; set; }
        public bool? ReadPrivacyNotice { get; set; }
        public bool? AcceptedTerms { get; set; }
        public string SpecialCommunicationNeeds { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
        public byte? RequestorType { get; set; }
        public string OrganisationName { get; set; }
        public int? ReferringGroupId { get; set; }
        public string Source { get; set; }
        public bool? Archive { get; set; }
        public Guid? Guid { get; set; }
        public bool? RequestorDefinedByGroup { get; set; }
        public byte? RequestType { get; set; }
        public bool? MultiVolunteer { get; set; }
        public bool? Repeat { get; set; }
        public bool? SuppressRecipientPersonalDetail { get; set; }
        public Guid? ParentGuid { get; set; }
    }
}
