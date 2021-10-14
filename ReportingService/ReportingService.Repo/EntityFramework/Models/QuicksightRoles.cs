using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingService.Repo.EntityFramework.Models
{
    public class QuicksightRoles
    {
        public QuicksightRoles()
        {
            RoleGroups = new HashSet<QuicksightRoleGroups>();
            Users = new HashSet<QuicksightUsers>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<QuicksightRoleGroups> RoleGroups { get; set; }
        public virtual ICollection<QuicksightUsers> Users { get; set; }
    }
}
