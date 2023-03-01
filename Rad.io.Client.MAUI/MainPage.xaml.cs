using Microsoft.Extensions.DependencyInjection;
using RadioBrowser.Net.Entities;
using RadioBrowser.Net.Services;
using RadioBrowser.Net.Converters;
using System.Diagnostics;

namespace Rad.io.Client.MAUI;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}


