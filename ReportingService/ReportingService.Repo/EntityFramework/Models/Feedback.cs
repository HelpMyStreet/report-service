using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class Feedback
    {
        public int JobId { get; set; }
        public string GroupName { get; set; }
        public string JobStatus { get; set; }
        public string Requester { get; set; }
        public string Recipient { get; set; }
        public string Volunteer { get; set; }
        public string GroupAdmin { get; set; }
    }
}
