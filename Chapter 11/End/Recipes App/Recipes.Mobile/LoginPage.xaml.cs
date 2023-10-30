using CommunityToolkit.Mvvm.Input;
using Recipes.Client.Core.Navigation;

namespace Recipes.Mobile;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
	}
}


public class LoginPageViewModel
{
    readonly INavigationService navigationService;
    public LoginPageViewModel(INavigationService navigation)
    {
       navigationService = navigation;
       //LoginCommand = new RelayCommand(() => navigationService.LoadApp());
    }

    public RelayCommand LoginCommand { get; }
}