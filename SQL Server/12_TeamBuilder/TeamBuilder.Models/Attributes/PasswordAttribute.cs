namespace TeamBuilder.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// Should contain one digit and one uppercase letter
    /// </summary>

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class PasswordAttribute
        : ValidationAttribute
    {
        private string specialSymbols = "!@#$%^&*()_+<>,.?";
        private int minLenght;
        private int maxLenght;

        public PasswordAttribute(int minLenght, int maxLenght)
        {
            this.minLenght = minLenght;
            this.maxLenght = maxLenght;
        }

        public bool Lowercase { get; set; }
        public bool Uppercase { get; set; }
        public bool Digit { get; set; }
        public bool SpecialSymbol { get; set; }

        public override bool IsValid(object value)
        {
            var pass = value.ToString();

            if (pass.Length < minLenght || pass.Length > maxLenght) { return false; }
            if (this.Lowercase && !pass.Any(c => char.IsLower(c))) { return false; }
            if (this.Uppercase && !pass.Any(c => char.IsUpper(c))) { return false; }
            if (this.Digit && !pass.Any(c => char.IsDigit(c))) { return false; }
            if (this.SpecialSymbol && !pass.Any(c => specialSymbols.Contains(c))) { return false; }

            return true;
        }
    }
}
