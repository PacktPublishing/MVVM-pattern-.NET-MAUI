using Recipes.Client.Core.ViewModels;

namespace Recipes.Mobile;

public partial class RecipeRatingDetailPage : ContentPage
{
	public RecipeRatingDetailPage(
		RecipeRatingsDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}