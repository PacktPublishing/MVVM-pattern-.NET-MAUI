using System.Text;
using System.Text.Json;

namespace Recipes.Client.Core.Features.Ratings;

public class RatingsService : IRatingsService
{
    RatingDto[]? ratings = null;
    Task<Stream> ratingsStreamTask;

    public async Task<RatingsSummaryDto> LoadRatingsSummary(string recipeId)
    {
        if (ratings is null)
        {
            ratings = await ReadRatingsFromStream();
        }

        var recipeRatings = await LoadRatings(recipeId);
        return new RatingsSummaryDto(recipeRatings.Count(), 4, recipeRatings.Sum(r => r.Rating) / recipeRatings.Count());
    }

    public async Task<RatingDto[]> LoadRatings(string recipeId)
    {
        if (ratings is null)
        {
            ratings = await ReadRatingsFromStream();
        }

        return ratings.Where(r => r.RecipeId == recipeId).ToArray();
    }

    private async Task<RatingDto[]> ReadRatingsFromStream()
    {
        var stream = await ratingsStreamTask;

        string json = string.Empty;
        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        {
            json = reader.ReadToEnd();
        }
        var serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return JsonSerializer.Deserialize<RatingDto[]>(json, serializeOptions) ?? new RatingDto[0];
    }

    public RatingsService(Task<Stream> ratingsStreamTask)
    {
        this.ratingsStreamTask = ratingsStreamTask;
    }
}
