using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RequestSubmission1
    {
        public int RequestId { get; set; }
        public byte? FreqencyId { get; set; }
        public int? NumberOfRepeats { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
