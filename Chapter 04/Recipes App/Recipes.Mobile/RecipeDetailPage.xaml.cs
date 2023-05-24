using Recipes.Client.Core.ViewModels;
using Recipes.Mobile.Converters;

namespace Recipes.Mobile;

public partial class RecipeDetailPage : ContentPage
{
	public RecipeDetailPage()
	{
		InitializeComponent();
		BindingContext = new RecipeDetailViewModel();

        //lblTitle.SetBinding(Label.TextProperty,
        //	nameof(RecipeDetailViewModel.Title),
        //	BindingMode.OneTime);

        //lblRating.SetBinding(Label.TextProperty,
            //$"{nameof(RecipeDetailViewModel.RatingDetail)}.{nameof(RecipeRatingsDetailViewModel.AverageRating)}",
            //converter: new RatingToStarsConverter());
    }
}