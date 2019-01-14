using Xamarin.Forms;

namespace GiftIt.Validation.Interfaces
{
    public interface IErrorStyle
    {
        void ShowError(View view, string message);
        void RemoveError(View view);
    }
}
