using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class VerificationVerificationAttempt
    {
        public DateTime? AttemptDate { get; set; }
        public int? UserId { get; set; }
        public string YotiRememberMeId { get; set; }
        public bool? Verified { get; set; }
        public bool? Dobmatch { get; set; }
        public bool? AgeMatch { get; set; }
        public bool? NotPreviouslyVerified { get; set; }
        public DateTime? CredentialAddedDate { get; set; }
    }
}
