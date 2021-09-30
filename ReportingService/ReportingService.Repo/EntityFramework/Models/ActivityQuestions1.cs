using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ActivityQuestions1
    {
        public int RequestFormVariantId { get; set; }
        public int ActivityId { get; set; }
        public int QuestionId { get; set; }
        public int? Order { get; set; }
        public int? Required { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
