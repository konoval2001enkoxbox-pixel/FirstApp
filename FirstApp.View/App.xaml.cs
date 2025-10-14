using FirstApp.View.Security;
using System;

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
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                var exception = e.ExceptionObject as Exception;
                // Log exception here
            };
        }
        protected override void OnSleep()
        {
            Storage.ClearSecureStorage();
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "FirstApp.View" };
        }
    }
}
