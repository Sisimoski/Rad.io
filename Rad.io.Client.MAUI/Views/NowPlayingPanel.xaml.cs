namespace Rad.io.Client.MAUI.Views;

public partial class NowPlayingPanel : ContentView
{
    public NowPlayingPanel()
    {
        InitializeComponent();
    }

    void playStopButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if (mediaElement.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
        {
            mediaElement.Pause();
        } else if (mediaElement.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Paused)
        {
            mediaElement.Play();
        }
        
    }
}