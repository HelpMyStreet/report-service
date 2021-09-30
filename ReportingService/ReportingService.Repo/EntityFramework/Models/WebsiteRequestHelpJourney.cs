using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class WebsiteRequestHelpJourney
    {
        public int GroupId { get; set; }
        public string Group { get; set; }
        public string Source { get; set; }
        public string RequestHelpFormVariant { get; set; }
        public string TargetGroups { get; set; }
        public bool? AccessRestrictedByRole { get; set; }
        public bool? RequestorDefinedByGroup { get; set; }
        public bool? RequestsRequireApproval { get; set; }
        public bool? SuppressRecipientPersonalDetails { get; set; }
    }
}
