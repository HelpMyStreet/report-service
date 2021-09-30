using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ViewRecentActivity
    {
        public DateTime? Date { get; set; }
        public string GroupName { get; set; }
        public string NewUsersFromLandingPage { get; set; }
        public int? UsersLeaving { get; set; }
        public int? Requests { get; set; }
    }
}
