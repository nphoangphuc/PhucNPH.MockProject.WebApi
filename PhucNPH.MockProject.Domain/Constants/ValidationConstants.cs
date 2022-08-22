using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhucNPH.MockProject.Domain.Constants
{
    public static class ValidationConstants
    {
        public static class Messages
        {
            public static readonly Func<string, string> FieldIsRequried = value => $"{value} is required";
            public static readonly Func<string, int, string> MinLengthRequired = (fieldName,minLength) 
                => $"{fieldName} must be more than {minLength} characters";
        }

        public static class ExceptionType
        {
            public const string DuplicatedUsername = "unique index 'IX_Employees_Username'";
        }

        public static class Constants
        {
            public const int PasswordMinLength = 5;
        }


    }
}
