using Xamarin.Forms;

namespace Animater
{
    public partial class App : Application
    {
        public static int ScreenHeight { get; set; }
        static public int ScreenWidth { get; set; }

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
