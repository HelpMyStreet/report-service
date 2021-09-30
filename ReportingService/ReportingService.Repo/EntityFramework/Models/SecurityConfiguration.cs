using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class SecurityConfiguration
    {
        public int GroupId { get; set; }
        public bool? AllowAutonomousJoinersAndLeavers { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
