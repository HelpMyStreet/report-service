using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RequestHelpJourney
    {
        public int GroupId { get; set; }
        public string Source { get; set; }
        public byte? RequestHelpFormVariant { get; set; }
        public int? TargetGroups { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
        public bool? AccessRestrictedByRole { get; set; }
        public bool? RequestorDefinedByGroup { get; set; }
        public bool? RequestsRequireApproval { get; set; }
        public bool? SuppressRecipientPersonalDetails { get; set; }
    }
}
