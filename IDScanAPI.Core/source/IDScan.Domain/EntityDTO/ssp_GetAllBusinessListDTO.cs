using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDScan.Domain
{
    public partial class ssp_GetAllBusinessListDTO
    {
        public Nullable<long> RowNumber { get; set; }
        public Nullable<int> TotalCount { get; set; }
        public string BusinessId { get; set; }
        public string BusinessName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<int> Status { get; set; }
        public string UserId { get; set; }
        public string CreatedByUserName { get; set; }
        public string CustomField1 { get; set; }
        public string CustomField2 { get; set; }
    }
}
