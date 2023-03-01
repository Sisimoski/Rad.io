using Rad.io.Client.MAUI.Pages;
using Rad.io.Client.MAUI.Pages.FlyoutPageDemo;
using Rad.io.Client.MAUI.Pages.NavPagesDemo;
using Rad.io.Client.MAUI.Pages.TabbedPageDemo;

namespace Rad.io.Client.MAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();

		/* ContentPagesDemo */
		//MainPage = new DemoContentPage1();

		/* NavigationPagesDemo */
		//var navigationPage = new NavigationPage(new NavContentPageDemo1());
		//navigationPage.BarBackgroundColor = Color.FromArgb("#cfe2f3");
		//navigationPage.BarTextColor = Color.FromArgb("#212121");
		//MainPage = navigationPage;

		/* FlyoutPageDemo */
		//MainPage = new DemoFlyoutPage();

		/* TabbedPageDemo */
		//MainPage = new DemoTabbedPage();
	}
}

