using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingService.Repo.EntityFramework.Models
{
    public class QuicksightUsers
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public int RoleId { get; set; }

        public virtual QuicksightRoles Role { get; set; }
    }
}
