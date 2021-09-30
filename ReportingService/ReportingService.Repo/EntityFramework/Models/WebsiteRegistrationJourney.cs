using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class WebsiteRegistrationJourney
    {
        public int GroupId { get; set; }
        public string Group { get; set; }
        public string Source { get; set; }
        public string RegistrationFormVariant { get; set; }
    }
}
