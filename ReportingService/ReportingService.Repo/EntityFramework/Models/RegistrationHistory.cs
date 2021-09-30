using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RegistrationHistory
    {
        public int UserId { get; set; }
        public byte RegistrationStep { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
