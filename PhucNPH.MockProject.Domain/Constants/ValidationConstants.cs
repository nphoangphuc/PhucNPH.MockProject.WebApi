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
            public static readonly Func<string, string> InvalidDate = (fieldName) 
                => $"{fieldName} is not a valid date between {Constants.MinDate.ToString("MM/dd/yyyy")} and {Constants.MaxDate.ToString("MM/dd/yyyy")}";
        }

        public static class ExceptionType
        {
            public const string DuplicatedUsername = "unique index 'IX_Employees_Username'";
        }

        public static class Constants
        {
            public const int PasswordMinLength = 5;
            public static DateTime MinDate = DateTime.Parse("01/01/1900");
            public static DateTime MaxDate = DateTime.Now;
        }

        public static bool ValidateValidDateTime(DateTime dateTime)
        {
            var isValid = false;
            try
            {
                var validDate = DateTime.Parse(dateTime.ToString());

                isValid = validDate > Constants.MinDate && validDate < Constants.MaxDate;
            }
            catch (Exception)
            {
                return isValid;
            }

            return isValid;
        }
    }
}
