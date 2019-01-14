using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiftIt.MembershipPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login: ContentPage
	{
		public Login()
		{
			InitializeComponent();
		}

        private async void ForgotPassword_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPassword());
        }


    }
}