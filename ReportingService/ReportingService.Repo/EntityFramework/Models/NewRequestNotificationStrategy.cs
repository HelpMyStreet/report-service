using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class NewRequestNotificationStrategy
    {
        public int GroupId { get; set; }
        public byte? NewRequestNotificationStrategyId { get; set; }
        public int? MaxVolunteer { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
