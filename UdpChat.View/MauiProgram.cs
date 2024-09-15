using Microsoft.Extensions.Logging;
using UdpChat.View.View;
using UdpChat.View.ViewModel;

namespace UdpChat.View
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services
                .AddTransient<MainPage>()
                .AddTransient<MainViewModel>()
                .AddTransient<ProfilePage>()
                .AddTransient<ProfileViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
