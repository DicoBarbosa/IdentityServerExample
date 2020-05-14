using System.ComponentModel.DataAnnotations;

namespace TCM.IdentityServer.Core.Domain.CustomValidation
{
    public class CPFAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
            "O número de CPF não é válido.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var sum = 0;

            var CPF = (string)value;

            if (CPF.Length != 11)
                return new ValidationResult(GetErrorMessage());

            for (int i = 0; i < 9; i++)
                sum += int.Parse(CPF.ToCharArray()[i].ToString()) * multiplier1[i];

            var remainder1 = sum % 11 < 2 ? 0 : 11 - (sum % 11);

            if(!CPF.Substring(9,1).Equals(remainder1.ToString()))
                return new ValidationResult(GetErrorMessage());

            sum = 0;

            for(int i = 0; i < 10; i++)
                sum += int.Parse(CPF.ToCharArray()[i].ToString()) * multiplier2[i];

            var remainder2 = sum % 11 < 2 ? 0 : 11 - (sum % 11);

            if(!CPF.Substring(10, 1).Equals(remainder2.ToString()))
                return new ValidationResult(GetErrorMessage());

            return ValidationResult.Success;
        }

    }
}