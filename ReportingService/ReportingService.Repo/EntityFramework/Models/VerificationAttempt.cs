using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class VerificationAttempt
    {
        public string DateOfAttempt { get; set; }
        public int? UserId { get; set; }
        public string YotiRememberMeId { get; set; }
        public bool? Verified { get; set; }
        public bool? DobMatch { get; set; }
        public bool? AgeMatch { get; set; }
        public bool? NotPreviouslyVerified { get; set; }
        public bool? UserServiceUpdated { get; set; }
        public DateTime DateFrom { get; set; }
    }
}
