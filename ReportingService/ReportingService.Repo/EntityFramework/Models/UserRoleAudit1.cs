using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class UserRoleAudit1
    {
        public int Id { get; set; }
        public int? AuthorisedByUserId { get; set; }
        public int? UserId { get; set; }
        public int? GroupId { get; set; }
        public int? RoleId { get; set; }
        public DateTime? DateRequested { get; set; }
        public byte? ActionId { get; set; }
        public bool? Success { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
