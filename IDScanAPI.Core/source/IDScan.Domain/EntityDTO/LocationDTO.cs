using Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace IDScan.Domain
{

    public partial class LocationDTO
    {
        [Display(Name = "Location Id")]
        public string LocationId { get; set; }

        [Display(Name = "Business Id")]
        [StringLength(36, ErrorMessage = GlobalErrorMessages.FIELD_NOT_VALID, MinimumLength = 36)]
        [Required(ErrorMessage = GlobalErrorMessages.REQUIRED)]
        public string BusinessId { get; set; }

        [Display(Name = "Location Name")]
        [StringLength(14, ErrorMessage = GlobalErrorMessages.STRING_LENGTH, MinimumLength = 3)]
        [Required(ErrorMessage = GlobalErrorMessages.REQUIRED)]
        public string LocationName { get; set; }

        [Display(Name = "Status")]
        [Range(1, 2, ErrorMessage = GlobalErrorMessages.RANGE)]
        [Required(ErrorMessage = GlobalErrorMessages.REQUIRED)]
        public int Status { get; set; }

        public string CreatedBy { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public string DeletedBy { get; set; }

        public Nullable<System.DateTime> DeletedDate { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }
    }

}
