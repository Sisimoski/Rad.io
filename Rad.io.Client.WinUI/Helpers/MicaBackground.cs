using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices; // For DllImport
using WinRT; // required to support Window.As<ICompositionSupportsSystemBackdrop>()
using Microsoft.Extensions.Configuration;

namespace Rad.io.Client.WinUI.Helpers
{
    public class MicaBackground
    {
        private readonly Window _window;
        private MicaController _micaController = new();
        private SystemBackdropConfiguration _backdropConfiguration = new();
        private readonly WindowsSystemDispatcherQueueHelper _dispatcherQueueHelper = new();

        public MicaBackground(Window window)
        {
            _window = window;
        }

        public bool TrySetMicaBackdrop()
        {
            if (MicaController.IsSupported())
            {
                _dispatcherQueueHelper.EnsureWindowsSystemDispatcherQueueController();
                _window.Activated += WindowOnActivated;
                _window.Closed += WindowOnClosed;
                _backdropConfiguration.IsInputActive = true;
                _backdropConfiguration.Theme = SystemBackdropTheme.Dark;
                //_backdropConfiguration.Theme = _window.Content switch
                //{
                //    FrameworkElement { ActualTheme: ElementTheme.Dark } => SystemBackdropTheme.Dark,
                //    FrameworkElement { ActualTheme: ElementTheme.Light } => SystemBackdropTheme.Light,
                //    FrameworkElement { ActualTheme: ElementTheme.Default } => SystemBackdropTheme.Default,
                //    _ => throw new InvalidOperationException("Unknown theme")
                //};

                _micaController.AddSystemBackdropTarget(_window.As<ICompositionSupportsSystemBackdrop>());
                _micaController.SetSystemBackdropConfiguration(_backdropConfiguration);
                return true;
            }

            return false;
        }

        private void WindowOnClosed(object sender, WindowEventArgs args)
        {
            _micaController.Dispose();
            _micaController = null!;
            _window.Activated -= WindowOnActivated;
            _backdropConfiguration = null!;
        }

        private void WindowOnActivated(object sender, WindowActivatedEventArgs args)
        {
            _backdropConfiguration.IsInputActive = args.WindowActivationState is not WindowActivationState.Deactivated;
        }
    }
}
