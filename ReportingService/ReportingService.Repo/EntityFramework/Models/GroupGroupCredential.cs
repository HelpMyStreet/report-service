using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupGroupCredential
    {
        public int GroupId { get; set; }
        public string Group { get; set; }
        public int? DisplayOrder { get; set; }
        public string Credential { get; set; }
        public string CredentialType { get; set; }
        public string HowToAchieve { get; set; }
        public string WhatIsThisText { get; set; }
        public int? GroupActivitiesRequiringCredential { get; set; }
    }
}
