using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class MonitoringCommunicationMessage
    {
        public string MessageId { get; set; }
        public int? RecipientUserId { get; set; }
        public string TemplateName { get; set; }
        public string MinTimestamp { get; set; }
        public bool? MatchedToExpectedEmail { get; set; }
        public DateTime? DateLastModified { get; set; }
        public string Comments { get; set; }
    }
}
