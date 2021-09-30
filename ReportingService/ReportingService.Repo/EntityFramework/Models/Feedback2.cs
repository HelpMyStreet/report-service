using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class Feedback2
    {
        public int Id { get; set; }
        public DateTime? FeedbackDate { get; set; }
        public int? JobId { get; set; }
        public int? UserId { get; set; }
        public byte? RequestRoleTypeId { get; set; }
        public byte? FeedbackRatingTypeId { get; set; }
        public DateTime? DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
    }
}
