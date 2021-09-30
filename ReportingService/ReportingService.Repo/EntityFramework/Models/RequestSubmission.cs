using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RequestSubmission
    {
        public int RequestId { get; set; }
        public byte? FreqencyId { get; set; }
        public int? NumberOfRepeats { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
