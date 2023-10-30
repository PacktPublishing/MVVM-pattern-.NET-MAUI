namespace MVVM_Demo;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new AppShell();
    }
}