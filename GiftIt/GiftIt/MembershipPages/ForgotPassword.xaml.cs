using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiftIt.MembershipPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotPassword : ContentPage
	{
		public ForgotPassword ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Gönderildi", "Şifre değiştirme isteğiniz emailinize gönderildi", "OK");
        }
    }
}