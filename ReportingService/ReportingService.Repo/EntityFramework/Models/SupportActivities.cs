using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class SupportActivities
    {
        public int RequestId { get; set; }
        public int ActivityId { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
