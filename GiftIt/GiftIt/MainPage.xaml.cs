using GiftIt.MembershipPages;
using System;
using Xamarin.Forms;

namespace GiftIt
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Account());
        }
    }
}
