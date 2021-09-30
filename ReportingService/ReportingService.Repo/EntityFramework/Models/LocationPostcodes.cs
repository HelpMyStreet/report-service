using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class LocationPostcodes
    {
        public string Location { get; set; }
        public string Postcode { get; set; }
        public string Area { get; set; }
        public int? GroupId { get; set; }
    }
}
