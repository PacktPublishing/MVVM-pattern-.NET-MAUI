using System.Text;
using System.Text.Json;

namespace Recipes.Client.Core.Features.Recipes;

public class RecipeService : IRecipeService
{
    Task<Stream> recipesJsonStreamTask;
    RecipeDetailDto[]? recipeDetails = null;

    public async Task<RecipeDetailDto?> LoadRecipe(string id)
    {
        if (recipeDetails is null)
        {
            recipeDetails = await ReadRecipeDetailsFromStream();
        }

        return recipeDetails.SingleOrDefault(r => r.Id == id);
    }

    public async Task<LoadRecipesResponse> LoadRecipes(int pageSize = 7, int pageIndex = 0)
    {
        if (recipeDetails is null)
        {
            recipeDetails = await ReadRecipeDetailsFromStream();
        }

        return new LoadRecipesResponse(recipeDetails.Count(), pageIndex, pageSize,
            recipeDetails
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .Select(r => new RecipeOverviewItemDto(r.Id, r.Name, r.Image))
                .ToArray()
            );
    }

    private async Task<RecipeDetailDto[]> ReadRecipeDetailsFromStream()
    {
        var stream = await recipesJsonStreamTask;
        string json = string.Empty;
        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        {
            json = reader.ReadToEnd();
        }
        return JsonSerializer.Deserialize<RecipeDetailDto[]>(json) ?? new RecipeDetailDto[0];
    }

    public RecipeService(Task<Stream> recipesJsonStreamTask)
    {
        this.recipesJsonStreamTask = recipesJsonStreamTask;
    }
}
