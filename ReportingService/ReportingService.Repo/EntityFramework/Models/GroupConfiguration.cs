using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupConfiguration
    {
        public int GroupId { get; set; }
        public string Group { get; set; }
        public string ParentGroup { get; set; }
        public string GroupKey { get; set; }
        public string FriendlyName { get; set; }
        public string ShortName { get; set; }
        public string LinkUrl { get; set; }
        public bool? HomepageEnabled { get; set; }
        public bool? AllowAutonomousJoinersAndLeavers { get; set; }
        public bool? TasksEnabled { get; set; }
        public bool? ShiftsEnabled { get; set; }
        public string GeographicName { get; set; }
        public string GroupType { get; set; }
        public string JoinGroupPopUpDetail { get; set; }
    }
}
