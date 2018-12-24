using Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace IDScan.Domain
{

    public partial class BusinessDTO
    {
        [Display (Name ="Business Id")]
        public string BusinessId { get; set; }

        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Display(Name = "Business Name")]
        [StringLength(14, ErrorMessage = GlobalErrorMessages.STRING_LENGTH, MinimumLength = 3)]
        [Required(ErrorMessage = GlobalErrorMessages.REQUIRED)]
        public string BusinessName { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public Nullable<bool> IsDeleted { get; set; }

        public Nullable<bool> IsActive { get; set; }

        public Nullable<System.DateTime> DeletedDate { get; set; }

        public string DeletedBy { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = GlobalErrorMessages.REQUIRED)]
        [Range(1, 9, ErrorMessage = GlobalErrorMessages.RANGE)]
        public int Status { get; set; }

    }

}
