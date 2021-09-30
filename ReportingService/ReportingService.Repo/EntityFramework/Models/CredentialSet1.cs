using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class CredentialSet1
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int CredentialId { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
