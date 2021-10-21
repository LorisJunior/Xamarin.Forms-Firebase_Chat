using Firebase_Chat.Helpers;
using Firebase_Chat.ViewModel;
using System;
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
            if (Chat.Messages.Count > 0)
            {
                MessageList.ScrollTo(Chat.Messages.Count - 1);
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            Chat.InitMessages();

            Chat.InitSubscription();

            //Ao iniciar vai até a ultima mensagem recebida
            if (Chat.Messages.Count > 0)
            {
                MessageList.ScrollTo(Chat.Messages.Count - 1);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //Limpa a lista de mensagens
            Chat.Messages.SafeClear();

            //Deixa de observar as atualizações desta conversa
            Chat.Subscription.Dispose();
        }

    }
}