using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class EventHistory
    {
        public int? RecipientUserId { get; set; }
        public string TemplateName { get; set; }
        public string Event { get; set; }
        public string EventDate { get; set; }
        public DateTime DateFrom { get; set; }
        public string MessageId { get; set; }
        public string GroupId { get; set; }
        public string JobId { get; set; }
        public string RequestId { get; set; }
    }
}
