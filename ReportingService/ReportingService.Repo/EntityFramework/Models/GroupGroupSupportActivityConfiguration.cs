using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupGroupSupportActivityConfiguration
    {
        public int GroupId { get; set; }
        public string Group { get; set; }
        public string Activity { get; set; }
        public double? Radius { get; set; }
        public string SupportActivityInstructions { get; set; }
        public string ActivityDetails { get; set; }
        public string Intro { get; set; }
        public string Steps { get; set; }
        public string Close { get; set; }
    }
}
