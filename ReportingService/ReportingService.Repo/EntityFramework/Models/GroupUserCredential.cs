using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupUserCredential
    {
        public int GroupId { get; set; }
        public string Group { get; set; }
        public int UserId { get; set; }
        public string Credential { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? ValidUntil { get; set; }
        public int? AuthorisedByUserId { get; set; }
        public string Reference { get; set; }
        public string Notes { get; set; }
    }
}
