using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RequestJobStatus
    {
        public int JobId { get; set; }
        public byte JobStatusId { get; set; }
        public DateTime DateCreated { get; set; }
        public int? VolunteerUserId { get; set; }
        public int? CreatedByUserId { get; set; }
        public byte? JobStatusChangeReasonCodeID { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
