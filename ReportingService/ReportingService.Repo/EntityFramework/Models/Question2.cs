using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class Question2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte? QuestionType { get; set; }
        public bool? Required { get; set; }
        public string AdditionalData { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
