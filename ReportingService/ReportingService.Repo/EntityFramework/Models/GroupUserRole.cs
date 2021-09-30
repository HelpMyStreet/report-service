using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupUserRole
    {
        public int UserId { get; set; }
        public string Group { get; set; }
        public int IsReferringGroup { get; set; }
        public string Role { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
