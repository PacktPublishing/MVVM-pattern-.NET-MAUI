namespace Recipes.Client.Core.Messages;

public class FavoriteUpdateMessage
{
    public string RecipeId { get; }
    public bool IsFavorite { get; }

    public FavoriteUpdateMessage(string recipeId, 
        bool isFavorite)
    {
        RecipeId = recipeId;
        IsFavorite = isFavorite;
    }
}