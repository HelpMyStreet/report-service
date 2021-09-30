using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupGroupMapDetails
    {
        public int GroupId { get; set; }
        public string Group { get; set; }
        public byte MapLocationId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? ZoomLevel { get; set; }
    }
}
