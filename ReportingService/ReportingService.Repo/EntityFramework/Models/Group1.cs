using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class Group1
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int? ParentGroupId { get; set; }
        public string GroupKey { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
        public bool? ShiftsEnabled { get; set; }
        public bool? HomepageEnabled { get; set; }
        public bool? TasksEnabled { get; set; }
        public string GeographicName { get; set; }
        public byte? GroupType { get; set; }
        public string FriendlyName { get; set; }
        public string LinkUrl { get; set; }
        public string ShortName { get; set; }
        public string JoinGroupPopUpDetail { get; set; }
    }
}
