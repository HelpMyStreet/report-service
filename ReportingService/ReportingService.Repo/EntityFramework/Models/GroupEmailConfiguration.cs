using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class GroupEmailConfiguration
    {
        public int GroupId { get; set; }
        public string Configuration { get; set; }
        public byte CommunicationJobTypeId { get; set; }
        public DateTime DateFrom { get; set; }
        public int SysChangeVersion { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
