using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class PreComputedNearestPostcodes1
    {
        public int Id { get; set; }
        public string Postcode { get; set; }
        public byte[] CompressedNearestPostcodes { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
