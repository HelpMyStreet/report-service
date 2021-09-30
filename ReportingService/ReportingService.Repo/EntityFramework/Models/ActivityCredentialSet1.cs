using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ActivityCredentialSet1
    {
        public int GroupId { get; set; }
        public int ActivityId { get; set; }
        public int CredentialSetId { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
