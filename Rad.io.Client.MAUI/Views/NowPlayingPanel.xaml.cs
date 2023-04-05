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
            //playStopButton.ImageSource = "pause_fill.png";
            mediaElement.Pause();
        } else if (mediaElement.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Paused)
        {
            //playStopButton.ImageSource = "play_fill.png";
            mediaElement.Play();
        }
        
    }
}