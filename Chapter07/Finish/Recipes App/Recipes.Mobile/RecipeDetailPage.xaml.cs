using Recipes.Client.Core.ViewModels;

namespace Recipes.Mobile;

public partial class RecipeDetailPage : ContentPage
{
    public RecipeDetailPage(RecipeDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void Ratings_Tapped(object sender, TappedEventArgs e)
    {
        Shell.Current.GoToAsync("RecipeRating");
    }
}