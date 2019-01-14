
namespace GiftIt.Validation
{
    public class RequiredValidator : IValidationRule
    {
        public string ValidationMessage { get; set; } = "This field is required";

        public bool Check(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
