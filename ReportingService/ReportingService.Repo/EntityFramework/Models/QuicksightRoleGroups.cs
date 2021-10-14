using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingService.Repo.EntityFramework.Models
{
    public class QuicksightRoleGroups
    {
        public int RoleId { get; set; }
        public int GroupId { get; set; }

        public virtual QuicksightRoles Role { get; set; }
    }
}
