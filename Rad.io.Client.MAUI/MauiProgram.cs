using Microsoft.Extensions.Logging;
using RadioBrowser.Net.Services;

namespace Rad.io.Client.MAUI;

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
        builder.Services.AddRadioBrowserServices("Mozilla/5.0 (Macintosh; Intel Mac OS X 13_2_1) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.3 Safari/605.1.15");

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();
        app.Services.GetService<IStationService>();
        return app;
    }
}

