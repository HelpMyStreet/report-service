using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupMapDetails
    {
        public int GroupId { get; set; }
        public byte MapLocationId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? ZoomLevel { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
