using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class UserUser
    {
        public int UserId { get; set; }
        public string Postcode { get; set; }
        public DateTime? DateCreated { get; set; }
        public double? SupportRadiusMiles { get; set; }
        public string ReferringGroup { get; set; }
        public string Source { get; set; }
        public string Activties { get; set; }
        public string Roles { get; set; }
        public int? AcceptedRequests { get; set; }
    }
}
