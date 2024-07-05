using System;

using System.Text.RegularExpressions;

namespace BL.ValidatorCredentialsManager
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public ValidationResult()
        {
            IsValid = true;
            Errors = new Dictionary<string, string>();
        }
    }

    public class Validator
    {
        public ValidationResult ValidateCred(string email, string phoneNumber, string password)
        {
            ValidationResult result = new ValidationResult();

            // Validate email
            if (!IsValidEmail(email))
            {
                result.IsValid = false;
                result.Errors.Add("email", "Invalid email format.");
            }

            // Validate Costa Rican phone number
            if (!IsValidCostaRicanPhoneNumber(phoneNumber))
            {
                result.IsValid = false;
                result.Errors.Add("phone", "Incorrect Costa Rican phone number format.");
            }

            // Validate password
            string passwordError;
            if (!IsValidPassword(password, out passwordError))
            {
                result.IsValid = false;
                result.Errors.Add("password", passwordError);
            }

            return result;
        }

        public ValidationResult ValidatePassword(string password)
        {
            ValidationResult result = new ValidationResult();

            // Validate password
            string passwordError;
            if (!IsValidPassword(password, out passwordError))
            {
                result.IsValid = false;
                result.Errors.Add("password", passwordError);
            }

            return result;

        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidCostaRicanPhoneNumber(string phoneNumber)
        {
            // Costa Rican phone numbers are 8 digits long and start with 2, 4, 5, 6, 7, or 8.
            return Regex.IsMatch(phoneNumber, @"^[2-8][0-9]{7}$");
        }

        private bool IsValidPassword(string password, out string error)
        {
            error = string.Empty;

            if (password.Length < 8)
            {
                error = "Password must be at least 8 characters long.";
                return false;
            }

            if (!Regex.IsMatch(password, @"[A-Za-z]"))
            {
                error = "Password must contain at least one letter.";
                return false;
            }

            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                error = "Password must contain at least one number.";
                return false;
            }

            if (!Regex.IsMatch(password, @"[\W_]"))
            {
                error = "Password must contain at least one symbol.";
                return false;
            }

            return true;
        }
    }

}