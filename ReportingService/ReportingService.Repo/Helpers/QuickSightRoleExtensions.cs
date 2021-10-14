using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportingService.Repo.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportingService.Repo.Helpers
{
    public static class QuickSightRoleExtensions
    {
        public static void SetQuickSightRolesData(this EntityTypeBuilder<QuicksightRoles> entity)
        {
            var groups = Enum.GetValues(typeof(Groups)).Cast<Groups>();

            foreach (var group in groups.Where(x=> x.IsEnabled()))
            {
                entity.HasData(new QuicksightRoles { Id = (int) group, RoleName = $"{group.ToString()}_Admin" });
            }
        }
    }
}
