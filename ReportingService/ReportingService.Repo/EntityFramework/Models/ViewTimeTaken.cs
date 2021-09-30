using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ViewTimeTaken
    {
        public int JobId { get; set; }
        public DateTime? DateRequested { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? DateAccepted { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime? DateCancelled { get; set; }
        public decimal? HrsRequestToApprove { get; set; }
        public decimal? HrsOpenToAccept { get; set; }
        public decimal? HrsAcceptToComplete { get; set; }
        public decimal? HrsRequestToCancel { get; set; }
        public int Overdue { get; set; }
    }
}
