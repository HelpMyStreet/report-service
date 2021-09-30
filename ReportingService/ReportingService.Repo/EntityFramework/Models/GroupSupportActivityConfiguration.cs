using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupSupportActivityConfiguration
    {
        public int GroupId { get; set; }
        public int SupportActivityId { get; set; }
        public short? SupportActivityInstructionsId { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
        public double? Radius { get; set; }
    }
}
