using Recipes.Client.Core.ViewModels;

namespace Recipes.Mobile;

public partial class AddRatingPage : ContentPage
{
	public AddRatingPage(AddRatingViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}