using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ViewEmailTemplateUnsubscribes
    {
        public int? RecipientUserId { get; set; }
        public string TemplateName { get; set; }
        public string Event { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }
}
