using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class ViewDroppedEmailAddresses
    {
        public int? RecipientUserId { get; set; }
        public int? Delivered { get; set; }
        public int? Dropped { get; set; }
    }
}
