using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ExpectedEmails
    {
        public int? RecipientUserId { get; set; }
        public byte[] RecipientEmailAddress { get; set; }
        public string TemplateName { get; set; }
        public DateTime? TimestampExpected { get; set; }
        public int? GroupId { get; set; }
        public int? JobId { get; set; }
        public int? RequestId { get; set; }
        public string Details { get; set; }
        public bool? Unsubscribed { get; set; }
        public DateTime? MinTimestampProcessed { get; set; }
        public DateTime? MinTimestampDelivered { get; set; }
        public DateTime? MinTimestampDropped { get; set; }
        public int? DistinctMessageIds { get; set; }
        public bool? Issue { get; set; }
        public string IssueDescription { get; set; }
        public int? EmailsExpected { get; set; }
        public bool? JoinUpdated { get; set; }
        public int? RecipientOrder { get; set; }
        public DateTime? MinTimestampInteraction { get; set; }
        public string SingleMessageId { get; set; }
    }
}
