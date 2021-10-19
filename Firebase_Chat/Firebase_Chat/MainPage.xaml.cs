using Firebase_Chat.Views;
using System;
using Xamarin.Forms;

namespace Firebase_Chat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HubPage());
        }
    }
}
