using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Navigation;
using Rad.io.Client.WinUI.Interfaces;
using Rad.io.Client.WinUI.Services;

namespace Rad.io.Client.WinUI.ViewModels;
public class ShellViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    private bool isBackEnabled;
    private object? selected;

    public INavigationService NavigationService
    {
        get;
    }
    public bool IsBackEnabled
    {
        get => isBackEnabled;
        set
        {
            isBackEnabled = value;
            RaisePropertyChanged();
        }
    }
    public object? Selected
    {
        get => selected;
        set
        {
            selected = value;
            RaisePropertyChanged();
        }
    }
    public ShellViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }
}
