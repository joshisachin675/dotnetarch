using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class Enumaration
    {
       public enum Status 
        {
            Active = 1,
            Inactive = 2
        }
        public enum CardType
        {
            All = 1,
            IDCardOnly = 2,
           CreditCardOnly = 2
        }
        public enum CheckExist
        {
            AlreadyExists = 1
        }
        public enum LoginProvide
        {
            Google = 1
        }
    }
}
