using Firebase_Chat.Services;
using Firebase_Chat.ViewModel;
using System;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Firebase_Chat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HubPage : ContentPage
    {
        public string GroupKey { get; set; }

        SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        ChatVM Chat;
        public HubPage()
        {
            InitializeComponent();
            Chat = DependencyService.Get<ChatVM>();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await semaphoreSlim.WaitAsync();

            //GroupKey = await FirebaseService.GetNewChatGroupKey();//Todo apagar o comentário

            //Todo - Teste passar o nome pelo construtor ChatPage(name.Text)
            Chat.Author = name.Text;
            //Chat.GroupKey = GroupKey; //Todo apagar o comentário

            await Navigation.PushAsync(new ChatPage());

            semaphoreSlim.Release();
        }
    }
}