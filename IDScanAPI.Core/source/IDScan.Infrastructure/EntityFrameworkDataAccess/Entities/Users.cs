using System;
using System.Collections.Generic;
using System.Text;

namespace IDScan.Infrastructure.EntityFrameworkDataAccess.Entities
{
    public class User
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Identifier { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int Role { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string LoginProvider { get; set; }
        public string ProfileImage { get; set; }
    }
}
