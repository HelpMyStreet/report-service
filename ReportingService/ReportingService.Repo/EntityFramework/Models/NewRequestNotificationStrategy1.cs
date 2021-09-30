using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class NewRequestNotificationStrategy1
    {
        public int GroupId { get; set; }
        public byte? NewRequestNotificationStrategyId { get; set; }
        public int? MaxVolunteer { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
