using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RequestJobAvailableToGroup
    {
        public int JobId { get; set; }
        public int? RequestId { get; set; }
        public string Group { get; set; }
        public int IsReferringGroup { get; set; }
    }
}
