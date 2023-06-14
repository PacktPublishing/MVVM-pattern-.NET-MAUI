namespace Recipes.Client.Core.ViewModels;

public class RecipeListItemViewModel
{
    public string Id { get; set; }
    public string? Image { get; set; }
    public string Title { get; set; }

    public RecipeListItemViewModel(string id, string title, string? image = null)
    {
        Id = id;
        Title = title;
        Image = image;
    }
}