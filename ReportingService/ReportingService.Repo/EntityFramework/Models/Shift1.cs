using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class Shift1
    {
        public int RequestId { get; set; }
        public DateTime? StartDate { get; set; }
        public int? ShiftLength { get; set; }
        public int? LocationId { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
