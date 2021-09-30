using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupCredential
    {
        public int GroupId { get; set; }
        public int CredentialId { get; set; }
        public byte? CredentialTypeId { get; set; }
        public string Name { get; set; }
        public string HowToAchieve { get; set; }
        public int? DisplayOrder { get; set; }
        public byte? CredentialVerifiedById { get; set; }
        public string HowToAchieveCtaDestination { get; set; }
        public string WhatIsThis { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
