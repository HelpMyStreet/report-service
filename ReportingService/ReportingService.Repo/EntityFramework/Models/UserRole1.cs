using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class UserRole1
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int GroupId { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
