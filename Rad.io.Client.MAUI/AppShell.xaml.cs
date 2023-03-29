using Rad.io.Client.MAUI.Pages;

namespace Rad.io.Client.MAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ExploreRadiosPage), typeof(ExploreRadiosPage));
	}
}

