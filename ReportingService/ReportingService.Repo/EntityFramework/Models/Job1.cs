using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class Job1
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public byte? SupportActivityId { get; set; }
        public string Details { get; set; }
        public DateTime DueDate { get; set; }
        public bool? IsHealthCritical { get; set; }
        public byte? JobStatusId { get; set; }
        public int? VolunteerUserId { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
        public byte? DueDateTypeId { get; set; }
        public string Reference { get; set; }
        public DateTime? NotBeforeDate { get; set; }
    }
}
