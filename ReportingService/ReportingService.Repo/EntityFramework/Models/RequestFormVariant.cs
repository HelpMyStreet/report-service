using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RequestFormVariant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
