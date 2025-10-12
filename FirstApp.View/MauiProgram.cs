using CommunityToolkit.Maui.Core;
using FirstApp.Interface;
using FirstApp.MAUIRepository;
using FirstApp.View.Service;
using Microsoft.Extensions.Logging;

namespace FirstApp.View
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddScoped<IRepositoryMAUI, RepositoryMAUI>();
            builder.Services.AddSingleton<NotificationService>();

            builder.Services.AddHttpClient("MyApi", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5039/");
                //client.BaseAddress = new Uri("http://10.0.2.2:5039/");
                //client.BaseAddress = new Uri("http://192.168.100.5:5039/");
            });
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
