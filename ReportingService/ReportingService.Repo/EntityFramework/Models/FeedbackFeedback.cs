using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class FeedbackFeedback
    {
        public int FeedbackId { get; set; }
        public DateTime? FeedbackDate { get; set; }
        public int? JobId { get; set; }
        public string Activity { get; set; }
        public string Group { get; set; }
        public string JobStatus { get; set; }
        public int? UserId { get; set; }
        public string RequestRoleType { get; set; }
        public string FeedbackRatingType { get; set; }
    }
}
