using Xamarin.Forms;

namespace Firebase_Chat
{
    public partial class App : Application
    {
        public static string groupKey = "-MmFpQ7wGtihPDXMHWea";
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
