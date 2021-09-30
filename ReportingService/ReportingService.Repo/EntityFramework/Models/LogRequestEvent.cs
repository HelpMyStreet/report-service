using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class LogRequestEvent
    {
        public int RequestId { get; set; }
        public DateTime DateRequested { get; set; }
        public byte RequestEventId { get; set; }
        public int? JobId { get; set; }
        public int? UserId { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
