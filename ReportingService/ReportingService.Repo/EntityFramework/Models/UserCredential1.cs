using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class UserCredential1
    {
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public int CredentialId { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? ValidUntil { get; set; }
        public int? AuthorisedByUserId { get; set; }
        public string Reference { get; set; }
        public string Notes { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
