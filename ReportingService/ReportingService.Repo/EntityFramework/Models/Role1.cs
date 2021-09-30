using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class Role1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
