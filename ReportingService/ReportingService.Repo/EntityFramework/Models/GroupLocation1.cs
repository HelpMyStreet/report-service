using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupLocation1
    {
        public int GroupId { get; set; }
        public int LocationId { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
