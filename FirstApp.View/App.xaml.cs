using FirstApp.View.Security;

namespace FirstApp.View
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Storage.ClearSecureStorage();
            };
        }
        //protected override void OnSleep()
        //{
        //    Storage.ClearSecureStorage();
        //}
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "FirstApp.View" };
        }
    }
}
