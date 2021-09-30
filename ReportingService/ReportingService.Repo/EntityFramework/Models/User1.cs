using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class User1
    {
        public int Id { get; set; }
        public string FirebaseUid { get; set; }
        public string PostalCode { get; set; }
        public bool? EmailSharingConsent { get; set; }
        public bool? MobileSharingConsent { get; set; }
        public bool? OtherPhoneSharingConsent { get; set; }
        public bool? HmscontactConsent { get; set; }
        public bool? IsVolunteer { get; set; }
        public bool? IsVerified { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? StreetChampionRoleUnderstood { get; set; }
        public bool? SupportVolunteersByPhone { get; set; }
        public double? SupportRadiusMiles { get; set; }
        public DateTime DateFrom { get; set; }
        public string SysChangeOperation { get; set; }
        public int? ReferringGroupId { get; set; }
        public string Source { get; set; }
    }
}
