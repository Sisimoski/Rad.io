using Microsoft.Extensions.Logging;
using Rad.io.Client.MAUI.ViewModels;
using Rad.io.Client.MAUI.Pages;
using RadioBrowser.Net.Services;
using CommunityToolkit.Maui;
using RadioBrowser;
using Rad.io.Client.MAUI.Views;
using Microsoft.Maui.LifecycleEvents;
using MauiIcons.SegoeFluent;
using MauiIcons.Material;
using MauiIcons.FluentFilled;
#if WINDOWS10_0_17763_0_OR_GREATER
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
using Microsoft.UI.Xaml;
using WinRT;
using Rad.io.Client.MAUI.WinUI;
using Rad.io.Client.MAUI.Platforms.Windows;
#endif

namespace Rad.io.Client.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .UseSegoeFluentMauiIcons()
            .UseFluentFilledMauiIcons()
            .UseMaterialMauiIcons()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Lato-Regular.ttf", "LatoRegular");
                fonts.AddFont("Lato-Bold.ttf", "LatoBold");
                fonts.AddFont("Lato-Thin.ttf", "LatoThin");
            });
        builder.Services.AddRadioBrowserServices("Mozilla/5.0 (Macintosh; Intel Mac OS X 13_2_1) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.3 Safari/605.1.15");
        builder.Services.AddSingleton<IRadioBrowserClient>(new RadioBrowserClient(apiUrl: "de1.api.radio-browser.info"));

        builder.Services.AddSingleton<NowPlayingPage>();
        builder.Services.AddSingleton<NowPlayingViewModel>();
        builder.Services.AddTransient<ExploreRadiosPage>();
        builder.Services.AddTransient<ExploreRadiosViewModel>();
        builder.Services.AddSingleton<ExploreCountriesPage>();
        builder.Services.AddSingleton<ExploreCountriesViewModel>();

        builder.ConfigureLifecycleEvents(events =>
        {
#if WINDOWS10_0_17763_0_OR_GREATER

            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    window.TryMicaOrAcrylic();
                });
            });
#endif
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();
        app.Services.GetService<IStationService>();
        return app;
    }
}

