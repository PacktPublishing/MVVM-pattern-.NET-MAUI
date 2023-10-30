namespace MVVM_Demo;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //await Shell.Current.GoToAsync("about");
        //await Shell.Current.GoToAsync("about?foo=bar");
        await Shell.Current.GoToAsync("about",
            new Dictionary<string, object>()
            { 
                {"foo", "bar" }
            });
    }
}