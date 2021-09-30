using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class JobQuestions1
    {
        public int JobId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
