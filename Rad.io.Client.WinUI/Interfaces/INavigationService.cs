using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad.io.Client.WinUI.Interfaces
{
    public interface INavigationService
    {
        //string CurrentPage { get; }
        //void NavigateTo(string page);
        //void NavigateTo(string page, object parameter);
        //void GoBack();

        event NavigatedEventHandler Navigated;

        bool CanGoBack { get; }

        Frame Frame { get; }

        bool NavigateTo(Type page, object parameter = null, bool clearNavigation = false);

        bool GoBack();
    }
}
