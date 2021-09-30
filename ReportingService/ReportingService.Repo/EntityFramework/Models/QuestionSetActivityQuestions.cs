using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class QuestionSetActivityQuestions
    {
        public string RequestFormVariant { get; set; }
        public string Activity { get; set; }
        public int? Order { get; set; }
        public string Question { get; set; }
        public int? Required { get; set; }
        public string QuestionType { get; set; }
        public string QuestionWording { get; set; }
        public string AddtionalData { get; set; }
    }
}
