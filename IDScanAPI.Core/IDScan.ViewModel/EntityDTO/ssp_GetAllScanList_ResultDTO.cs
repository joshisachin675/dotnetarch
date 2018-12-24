using System;

namespace IDScan.ViewModel
{
    public partial class ssp_GetAllScanList_ResultDTO
    {
        public string ScanID { get; set; }
        public string LocationID { get; set; }
        public string NameOnCard { get; set; }
        public System.DateTime ScanDate { get; set; }
        public Nullable<int> Gender { get; set; }
        public Nullable<int> Age { get; set; }
        public string IdNumber { get; set; }
        public Nullable<int> CardType { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string LocationName { get; set; }
        public string CreatedByName { get; set; }
        public string CustomField1 { get; set; }
        public string CustomField2 { get; set; }
    }
}
