using Rad.io.Client.MAUI.Pages;

namespace Rad.io.Client.MAUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

#if WINDOWS || MACCATALYST
        MainPage = new DesktopShell();
#else
        MainPage = new Shell();
#endif
    }
}