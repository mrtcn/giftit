using System.Text.RegularExpressions;

namespace GiftIt.Validation
{
    public class FormatValidator : IValidationRule
    {
        public string ValidationMessage { get; set; } = "Invalid format";
        public string Format { get; set; }

        public bool Check(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Regex format = new Regex(Format);

                return format.IsMatch(value);
            }
            else
            {
                return false;
            }
        }
    }
}
