using CommunityToolkit.Maui.Behaviors;
using Recipes.Client.Core.ViewModels;
using Recipes.Mobile.Converters;

namespace Recipes.Mobile;

public partial class RecipeDetailPage : ContentPage
{
	public RecipeDetailPage()
	{
		InitializeComponent();
		BindingContext = new RecipeDetailViewModel();
    }
}