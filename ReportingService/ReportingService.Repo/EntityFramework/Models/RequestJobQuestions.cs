using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RequestJobQuestions
    {
        public int JobId { get; set; }
        public int? RequestId { get; set; }
        public string Question { get; set; }
        public string Name { get; set; }
        public string Answer { get; set; }
    }
}
