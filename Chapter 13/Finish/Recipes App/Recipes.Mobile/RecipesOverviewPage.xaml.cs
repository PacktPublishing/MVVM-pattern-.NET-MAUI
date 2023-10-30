using Recipes.Client.Core.ViewModels;

namespace Recipes.Mobile;

public partial class RecipesOverviewPage : ContentPage
{
    
    public RecipesOverviewPage(
		RecipesOverviewViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}