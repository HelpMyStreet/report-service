using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class PostcodeLookup
    {
        public string PostcodeDistrict { get; set; }
        public string Locality { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public int? ActivePostcodes { get; set; }
        public string Country { get; set; }
    }
}
