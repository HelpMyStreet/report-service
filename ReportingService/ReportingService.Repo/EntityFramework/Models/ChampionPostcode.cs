using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ChampionPostcode
    {
        public int UserId { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
