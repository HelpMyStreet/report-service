using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class SupportActivity2
    {
        public int UserId { get; set; }
        public byte ActivityId { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
