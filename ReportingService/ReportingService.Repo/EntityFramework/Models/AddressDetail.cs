using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class AddressDetail
    {
        public int Id { get; set; }
        public int? PostcodeId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Locality { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
