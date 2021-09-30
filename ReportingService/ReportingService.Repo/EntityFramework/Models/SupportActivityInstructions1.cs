using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class SupportActivityInstructions1
    {
        public short SupportActivityInstructionsId { get; set; }
        public string Instructions { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
