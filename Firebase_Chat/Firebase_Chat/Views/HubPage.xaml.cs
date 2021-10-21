using Firebase_Chat.Helpers;
using Firebase_Chat.Models;
using Firebase_Chat.Services;
using Firebase_Chat.ViewModel;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Firebase_Chat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HubPage : ContentPage
    {
        HubVM hub;

        ChatVM Chat;
        public HubPage()
        {
            InitializeComponent();

            hub = DependencyService.Get<HubVM>();

            Chat = DependencyService.Get<ChatVM>();

            BindingContext = hub;
        }
    }
}