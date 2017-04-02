namespace TeamBuilder.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class ExactLengthAttribute
        : ValidationAttribute
    {
        private int exactLength;

        public ExactLengthAttribute(int exactLength)
        {
            this.exactLength = exactLength;
        }
        public override bool IsValid(object value)
        {
            var text = value.ToString();
            if (text.Length != exactLength) { return false; }
            return true;
        }
    }
}
