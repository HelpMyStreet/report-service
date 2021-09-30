using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class Postcode
    {
        public int Id { get; set; }
        public string Postcode1 { get; set; }
        public DateTime? LastUpdated { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string FriendlyName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
