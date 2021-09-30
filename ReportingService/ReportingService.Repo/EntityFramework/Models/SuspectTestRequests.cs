using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class SuspectTestRequests
    {
        public int RequestId { get; set; }
        public string PostCode { get; set; }
        public string ReferringGroup { get; set; }
        public DateTime? DateRequested { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int? CreatedByUserId { get; set; }
        public string Requester { get; set; }
    }
}
