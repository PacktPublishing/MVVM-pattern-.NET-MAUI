using Recipes.Client.Core.ViewModels;

namespace Recipes.Mobile;

public partial class RecipeRatingDetailPage : ContentPage
{
	public RecipeRatingDetailPage()
	{
		InitializeComponent();
		BindingContext = new RecipeRatingsDetailViewModel("", "Classic Caesar Salad", 15);
	}
}