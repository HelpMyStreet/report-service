using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ViewShiftFilling
    {
        public int RequestId { get; set; }
        public DateTime? DateRequested { get; set; }
        public string GroupName { get; set; }
        public DateTime? StartDate { get; set; }
        public int? ShiftLength { get; set; }
        public int? Jobs { get; set; }
        public int? CancelledJobs { get; set; }
        public int? AcceptedDone { get; set; }
        public int? FreqVol { get; set; }
        public decimal? MinMinsToAccept { get; set; }
        public decimal? MaxMinsToAccept { get; set; }
    }
}
