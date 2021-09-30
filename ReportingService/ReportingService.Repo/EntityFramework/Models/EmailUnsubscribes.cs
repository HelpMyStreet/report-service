using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class EmailUnsubscribes
    {
        public int? RecipientUserId { get; set; }
        public string TemplateName { get; set; }
        public string Event { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? DateFrom { get; set; }
        public string MessageId { get; set; }
        public int? GroupId { get; set; }
        public int? JobId { get; set; }
        public int? RequestId { get; set; }
    }
}
