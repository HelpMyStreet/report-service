using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupNewRequestNotificationStrategy
    {
        public int GroupId { get; set; }
        public string Group { get; set; }
        public string NewRequestNotificationStrategy { get; set; }
        public int? MaxVolunteer { get; set; }
    }
}
