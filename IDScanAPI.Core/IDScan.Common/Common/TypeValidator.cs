using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class TypeValidatorAttribute : RegularExpressionAttribute
    {
        private readonly string dataType = "Integer";

        public TypeValidatorAttribute(string pattern) : base(pattern) { }

        public TypeValidatorAttribute(string pattern, string newDataType) : base(pattern)
        {
            dataType = newDataType;
        }

        public override bool IsValid(object value)
        {
            string newString = Convert.ToString(value).Trim();
            if (!string.IsNullOrEmpty(newString))
            {
                return base.IsValid(value);
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(ErrorMessage, name, dataType);
        }
    }
}
