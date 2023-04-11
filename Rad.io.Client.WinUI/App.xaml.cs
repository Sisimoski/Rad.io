using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Rad.io.Client.WinUI.ViewModels;
using Rad.io.Client.WinUI.Interfaces;
using Rad.io.Client.WinUI.Services;
using Rad.io.Client.WinUI.Views;
using RadioBrowser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Rad.io.Client.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        /// 
        public static Window MainWindow
        {
            get; set;
        }
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; private set; }

        public static Frame ContentFrame { get; set; }
        public App()
        {
            Services = RegisterServices();

            this.InitializeComponent();
        }

        private IServiceProvider RegisterServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IRadioBrowserClient>(new RadioBrowserClient(apiUrl: "de1.api.radio-browser.info"));
            
            serviceCollection.AddSingleton<ExploreCountriesPage>();
            serviceCollection.AddSingleton<ExploreCountriesViewModel>();
            serviceCollection.AddSingleton<ExploreRadiosPage>();
            serviceCollection.AddSingleton<ExploreRadiosViewModel>();
            serviceCollection.AddSingleton<NowPlayingViewModel>();
            serviceCollection.AddSingleton<ShellPage>();
            serviceCollection.AddSingleton<ShellViewModel>();

            return serviceCollection.BuildServiceProvider();
        }
        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {   
            if (App.MainWindow.Content == null)
            {
                App.Current.Services.GetService<ShellPage>();
                App.MainWindow.
            }

            //MainWindow = new MainWindow();
            //MainWindow.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private Window m_window;
    }
}
