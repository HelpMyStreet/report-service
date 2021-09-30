using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class UpdateHistory
    {
        public int RequestId { get; set; }
        public int JobId { get; set; }
        public DateTime DateCreated { get; set; }
        public string FieldChanged { get; set; }
        public int? CreatedByUserId { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int? QuestionId { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
