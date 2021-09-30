using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RegistrationHistory1
    {
        public int UserId { get; set; }
        public byte RegistrationStep { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
