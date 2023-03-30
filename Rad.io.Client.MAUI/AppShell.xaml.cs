using Rad.io.Client.MAUI.Pages;

namespace Rad.io.Client.MAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ExploreCountriesPage), typeof(ExploreCountriesPage));
		Routing.RegisterRoute(nameof(ExploreRadiosPage), typeof(ExploreRadiosPage));
		Routing.RegisterRoute(nameof(NowPlayingPage), typeof(NowPlayingPage));
	}
}

