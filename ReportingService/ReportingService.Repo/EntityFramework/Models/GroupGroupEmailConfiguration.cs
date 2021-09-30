using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupGroupEmailConfiguration
    {
        public int GroupId { get; set; }
        public string Group { get; set; }
        public byte CommunicationJobTypeId { get; set; }
        public string GroupContent { get; set; }
        public string GroupSignature { get; set; }
        public string GroupPs { get; set; }
        public string ShowGroupLogo { get; set; }
    }
}
