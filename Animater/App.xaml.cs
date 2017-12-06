using Xamarin.Forms;

namespace Animater
{
    public partial class App : Application
    {
        static public int ScreenHeight;
        static public int ScreenWidth;

        public App()
        {
            InitializeComponent();

            MainPage = new GamePage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
