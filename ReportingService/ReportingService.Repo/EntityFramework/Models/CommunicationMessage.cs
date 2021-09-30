using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class CommunicationMessage
    {
        public string MessageId { get; set; }
        public bool? MatchedToExpectedEmail { get; set; }
        public string Comments { get; set; }
    }
}
