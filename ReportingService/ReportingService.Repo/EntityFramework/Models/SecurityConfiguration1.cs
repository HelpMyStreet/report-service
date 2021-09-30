using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class SecurityConfiguration1
    {
        public int GroupId { get; set; }
        public bool? AllowAutonomousJoinersAndLeavers { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
