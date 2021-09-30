using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RequestAnonymisation
    {
        public int? Order { get; set; }
        public string Anonymisation { get; set; }
        public int? Requests { get; set; }
    }
}
