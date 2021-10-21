

using Firebase_Chat.Models;
using Firebase_Chat.ViewModel;
using Firebase_Chat.Views;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

[assembly:Dependency(typeof(HubVM))]
namespace Firebase_Chat.ViewModel
{
    public class HubVM : BaseViewModel
    {
        public ObservableCollection<HubModel> Chats { get; private set; }

        SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        ChatVM Chat;
        public HubVM()
        {
            InitChatData();

            Chat = DependencyService.Get<ChatVM>();
        }

        public void InitChatData()
        {
            Chats = new ObservableCollection<HubModel>
            {
                new HubModel
                {
                    Author = "Lucia",
                    GroupKey = "Conversa1"
                },
                new HubModel
                {
                    Author = "Junior",
                    GroupKey = "Conversa2"
                },
                new HubModel
                {
                    Author = "Ronaldo",
                    GroupKey = "Conversa3"
                },
            };
        }
        public ICommand GoToChat => new Command(async sender =>
        {
            CollectionView view = sender as CollectionView;

            if (view.SelectedItem != null)
            {
                await semaphoreSlim.WaitAsync();

                var selected = view.SelectedItem as HubModel;

                Chat.Author = selected.Author;

                Chat.GroupKey = selected.GroupKey;

                await Application.Current.MainPage.Navigation.PushAsync(new ChatPage());

                view.SelectedItem = null;

                semaphoreSlim.Release();
            }
        });
    }
}
