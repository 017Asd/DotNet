using System;

namespace Q1
{
    public static class Validator
    {
        public static void ValidateApplicantId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception("Applicant ID cannot be empty.");

            if (id.Length != 8)
                throw new Exception("Applicant ID must be exactly 8 characters.");

            if (!id.StartsWith("CH"))
                throw new Exception("Applicant ID must start with CH.");
        }

        public static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name cannot be empty.");

            if (name.Length < 4 || name.Length > 15)
                throw new Exception("Name must be between 4 and 15 characters.");
        }

        public static void ValidatePassingYear(int year)
        {
            if (year > DateTime.Now.Year)
                throw new Exception("Passing year cannot be in the future.");
        }
    }
}
