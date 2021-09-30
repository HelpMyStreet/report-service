using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class RegistrationJourney
    {
        public int GroupId { get; set; }
        public string Source { get; set; }
        public byte? RegistrationFormVariant { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
