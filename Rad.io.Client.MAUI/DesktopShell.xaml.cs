using Rad.io.Client.MAUI.Pages;

namespace Rad.io.Client.MAUI;

public partial class DesktopShell : Shell
{
	public DesktopShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ExploreCountriesPage), typeof(ExploreCountriesPage));
        Routing.RegisterRoute(nameof(ExploreRadiosPage), typeof(ExploreRadiosPage));
        Routing.RegisterRoute(nameof(RadioLibraryPage), typeof(RadioLibraryPage));
        Routing.RegisterRoute(nameof(NowPlayingPage), typeof(NowPlayingPage));
    }
}
