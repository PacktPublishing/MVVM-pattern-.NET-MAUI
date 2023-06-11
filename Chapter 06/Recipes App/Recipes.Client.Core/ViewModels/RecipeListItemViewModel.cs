namespace Recipes.Client.Core.ViewModels;

public class RecipeListItemViewModel
{
    public string Id { get; set; }
    public string? Image { get; set; }
    public string Title { get; set; }
    public double AvgRating { get; set; }
    public bool IsFavorite { get; set; }

    public RecipeListItemViewModel(string id, string title, bool isFavorite = false, string? image = null, double avgRating = 0)
    {
        Id = id;
        Title = title;
        IsFavorite = isFavorite;
        Image = image;
        AvgRating = avgRating;
    }
}