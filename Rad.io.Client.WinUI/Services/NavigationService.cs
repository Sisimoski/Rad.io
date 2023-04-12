using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rad.io.Client.WinUI.Interfaces;
using Microsoft.UI.Xaml.Navigation;

namespace Rad.io.Client.WinUI.Services
{
    //public class NavigationService : INavigationService
    //{
    //    private readonly IDictionary<string, Type> _pages = new ConcurrentDictionary<string, Type>();

    //    public const string RootPage = "(Root)";

    //    public const string UnknownPage = "(Unknown)";

    //    private static Frame AppFrame => (Frame)Window.Current.Content;

    //    public void Configure(string page, Type type)
    //    {
    //        if (_pages.Values.Any(v => v == type))
    //        {
    //            throw new ArgumentException($"The {type.Name} view has already been registered under another name.");
    //        }

    //        _pages[page] = type;
    //    }

    //    /// <summary>
    //    /// Gets the name of the currently displayed page.
    //    /// </summary>
    //    public string CurrentPage
    //    {
    //        get
    //        {
    //            var frame = AppFrame;

    //            if (frame.BackStackDepth == 0)
    //                return RootPage;

    //            if (frame.Content == null)
    //                return UnknownPage;

    //            var type = frame.Content.GetType();

    //            if (_pages.Values.All(v => v != type))
    //                return UnknownPage;

    //            var item = _pages.Single(i => i.Value == type);

    //            return item.Key;
    //        }
    //    }

    //    public void NavigateTo(string page)
    //    {
    //        NavigateTo(page, null);
    //    }

    //    public void NavigateTo(string page, object parameter)
    //    {
    //        if (!_pages.ContainsKey(page))
    //        {
    //            throw new ArgumentException($"Unable to find a page registered with the name {page}.");
    //        }

    //        AppFrame.Navigate(_pages[page], parameter);
    //    }

    //    public void GoBack()
    //    {
    //        if (AppFrame?.CanGoBack == true)
    //        {
    //            AppFrame.GoBack();
    //        }
    //    }
    //}

    public class NavigationService : INavigationService
    {
        private object _lastParameterUsed;
        private Frame _frame;

        public event NavigatedEventHandler Navigated;

        public Frame Frame
        {
            get
            {
                if (_frame == null)
                {
                    _frame = App.MainWindow.Content as Frame;
                    RegisterFrameEvents();
                }

                return _frame;
            }
        }

        public bool CanGoBack => Frame.CanGoBack;


        private void RegisterFrameEvents()
        {
            if (Frame != null)
            {
                Frame.Navigated += OnNavigated;
            }
        }

        private void UnregisterFrameEvents()
        {
            if (Frame != null)
            {
                Frame.Navigated -= OnNavigated;
            }
        }

        public bool GoBack()
        {
            if (CanGoBack)
            {
                var vmBeforeNavigation = Frame.GetPageViewModel();
                Frame.GoBack();
                if (vmBeforeNavigation is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedFrom();
                }

                return true;
            }

            return false;
        }

        public bool NavigateTo(Type page, object parameter = null, bool clearNavigation = false)
        {
            if (Frame.Content?.GetType() != page || parameter != null && !parameter.Equals(_lastParameterUsed))
            {
                Frame.Tag = clearNavigation;
                var vmBeforeNavigation = Frame.GetPageViewModel();
                var navigated = Frame.Navigate(page, parameter);
                if (navigated)
                {
                    _lastParameterUsed = parameter;
                    if (vmBeforeNavigation is INavigationAware navigationAware)
                    {
                        navigationAware.OnNavigatedFrom();
                    }
                }

                return navigated;
            }

            return false;
        }

        public void CleanNavigation()
            => Frame.BackStack.Clear();

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (sender is Frame frame)
            {
                bool clearNavigation = (bool)frame.Tag;
                if (clearNavigation)
                {
                    frame.BackStack.Clear();
                }

                if (frame.GetPageViewModel() is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(e.Parameter);
                }

                Navigated?.Invoke(sender, e);
            }
        }
    }

    public static class FrameExtensions
    {
        public static object GetPageViewModel(this Frame frame)
            => frame?.Content?.GetType().GetProperty("ViewModel")?.GetValue(frame.Content, null);
    }
}
