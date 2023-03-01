namespace Rad.io.Client.MAUI.Pages.NavPagesDemo;

public partial class NavContentPageDemo3 : ContentPage
{
	public NavContentPageDemo3()
	{
		InitializeComponent();
	}

    private async void closeButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}