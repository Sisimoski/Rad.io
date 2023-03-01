namespace Rad.io.Client.MAUI.Pages.NavPagesDemo;

public partial class NavContentPageDemo1 : ContentPage
{
	public NavContentPageDemo1()
	{
		InitializeComponent();
	}

    private async void navContentPage2Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new NavContentPageDemo2());
    }
}