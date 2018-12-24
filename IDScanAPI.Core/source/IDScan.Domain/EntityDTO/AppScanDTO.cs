
using System;
using System.ComponentModel.DataAnnotations;

namespace IDScan.Domain
{
    public partial class AppScanDTO
    {
        public string ScanID { get; set; }
        [Required]
        [StringLength(36, ErrorMessage = GlobalErrorMessages.FIELD_NOT_VALID, MinimumLength = 36)]
        public string LocationID { get; set; }
        [Required]
        public string NameOnCard { get; set; }
        public DateTime ScanDate { get; set; }
        [Required]
        public Nullable<int> Gender { get; set; }
        [Required]
        public Nullable<int> Age { get; set; }
        [Required]
        public string IdNumber { get; set; }
        [Required]
        public Nullable<int> CardType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<DateTime> DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string DocumenPath { get; set; }
        public Nullable<DateTime> CardExpireDate { get; set; }
        public string DeletedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string USDLVersion { get; set; }
        public string EyeColor { get; set; }
        public string Height { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Jurisdiction { get; set; }
        public string PostalCode { get; set; }
        public Nullable<DateTime> IssueDate { get; set; }
        public Nullable<DateTime> ExpirationDate { get; set; }
        public Nullable<int> IssuerId { get; set; }
        public Nullable<int> JurisdictionVersion { get; set; }
        public string VehicleClass { get; set; }
        public string Restrictions { get; set; }
        public string Endorsments { get; set; }
        public Nullable<int> CustomerId { get; set; }
    }
}
