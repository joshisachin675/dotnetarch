
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDScan.ViewModel
{ 
        public partial class ssp_GetAllLocationListDTO
    {
            public string locationid { get; set; }
            public string businessid { get; set; }
            public string locationname { get; set; }
            public int status { get; set; }
            public string createdby { get; set; }
            public Nullable<System.DateTime> createddate { get; set; }
            public string businessname { get; set; }
            public string CustomField1 { get; set; }
            public string CustomField2 { get; set; }
        } 
}
