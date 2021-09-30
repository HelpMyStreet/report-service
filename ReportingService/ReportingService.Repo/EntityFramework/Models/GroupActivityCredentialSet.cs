using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupActivityCredentialSet
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Activity { get; set; }
        public string Credentials { get; set; }
    }
}
