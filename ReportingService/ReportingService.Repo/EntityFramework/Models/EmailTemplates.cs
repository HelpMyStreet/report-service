using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class EmailTemplates
    {
        public string GroupName { get; set; }
        public string TemplateName { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
