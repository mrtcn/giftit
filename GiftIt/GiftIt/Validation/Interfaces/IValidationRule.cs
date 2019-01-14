
namespace GiftIt.Validation
{
    public interface IValidationRule
    {
        string ValidationMessage { get; set; }
        bool Check(string value);
    }
}
