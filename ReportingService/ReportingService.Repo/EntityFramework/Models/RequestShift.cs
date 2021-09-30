using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RequestShift
    {
        public int RequestId { get; set; }
        public string Group { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ShiftLength { get; set; }
        public int? JobsOnRequest { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }
        public int? EmailRecipients { get; set; }
    }
}
