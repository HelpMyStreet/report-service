using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ViewRequestVolume
    {
        public DateTime? WeekCommencing { get; set; }
        public DateTime? DateRequested { get; set; }
        public DateTime? DueDate { get; set; }
        public int RequestId { get; set; }
        public string ReferringGroup { get; set; }
        public string ParentGroup { get; set; }
        public int? CancelledRequest { get; set; }
        public int? Jobs { get; set; }
        public int? JobsAccepted { get; set; }
        public int? JobsOpen { get; set; }
        public int? JobsComplete { get; set; }
        public int? JobsCancelled { get; set; }
        public decimal? AvgMinsToFill { get; set; }
        public int? FilledLessThan24Hrs { get; set; }
        public string AvgTimeTakenToFill { get; set; }
    }
}
