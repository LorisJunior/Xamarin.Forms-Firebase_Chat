using Firebase.Database.Query;
using Firebase_Chat.Models;
using Firebase_Chat.Services;
using Firebase_Chat.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Firebase_Chat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        ChatVM Chat;

        public ChatPage()
        {
            InitializeComponent();

            Chat = DependencyService.Get<ChatVM>();

            BindingContext = Chat;

            Chat.Messages.CollectionChanged += Messages_CollectionChanged;
        }
        private void Messages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            MessageList.ScrollTo(Chat.Messages.Count - 1);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            Chat.InitMessages();

            Chat.InitSubscription();

            if (Chat.Messages.Count > 0)
            {
                MessageList.ScrollTo(Chat.Messages.Count - 1);
            }
        }
       
    }
}