using Recipes.Shared.Dto;

static class FavoritesDataStore
{
    static List<string> favorites = new List<string>();

    public static string[] GetFavorites(string userId)
    {
        return favorites.ToArray();
    }

    public static void StoreFavorite(string userId, FavoriteDto favorite)
    {
        if (favorites.Contains(favorite.RecipeId))
            return;
        favorites.Add(favorite.RecipeId);
    }

    public static void DeleteFavorite(string userId, string recipeId)
    {
        if (favorites.Contains(recipeId))
            favorites.Remove(recipeId);
    }
}