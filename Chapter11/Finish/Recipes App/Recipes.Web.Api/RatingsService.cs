using Recipes.Shared.Dto;
using System.Text.Json;
using System.Text;

namespace Recipes.Web.Api;

public class RatingsService
{
    public RatingsSummaryDto LoadRatingsSummary(string recipeId)
    {
        var ratings = ReadRatingsFromStream();

        var recipeRatings = LoadRatings(recipeId);
        return new RatingsSummaryDto(recipeRatings.Count(), 4, recipeRatings.Sum(r => r.Rating) / recipeRatings.Count());
    }

    public RatingDto[] LoadRatings(string recipeId)
    {
        var ratings = ReadRatingsFromStream();
        return ratings.Where(r => r.RecipeId == recipeId).ToArray();
    }

    RatingDto[] ReadRatingsFromStream()
    {
        string json = string.Empty;
        using (StreamReader reader = new StreamReader("ratings.json", Encoding.UTF8))
        {
            json = reader.ReadToEnd();
        }
        var serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return JsonSerializer.Deserialize<RatingDto[]>(json, serializeOptions) ?? new RatingDto[0];
    }
}
