﻿using Rad.io.Client.MAUI.Pages;

namespace Rad.io.Client.MAUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}