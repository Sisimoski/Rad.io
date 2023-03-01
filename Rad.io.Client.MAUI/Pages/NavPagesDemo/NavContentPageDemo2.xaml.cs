namespace Rad.io.Client.MAUI.Pages.NavPagesDemo;

public partial class NavContentPageDemo2 : ContentPage
{
	public NavContentPageDemo2()
	{
		InitializeComponent();
	}

    private async void navContentPage3Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NavContentPageDemo3());
    }

    private async void closeButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}