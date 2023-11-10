using Microsoft.Extensions.DependencyInjection;
using Recipes.Client.Core.Features.Favorites;
using Recipes.Client.Core.Features.Ratings;
using Recipes.Client.Core.Features.Recipes;
using Recipes.Mobile.Repositories;
using Refit;

namespace Recipes.Client.Repositories;

public static class ServiceCollectionExtension
{
    public static IServiceCollection 
        RegisterRepositories(
        this IServiceCollection services,
        RepositorySettings settings)
    {
        services.AddSingleton(
            (s) => RestService.For<IRatingsApi>(settings.HttpClient));
        services.AddSingleton(
            (s) => RestService.For<IRecipeApi>(settings.HttpClient));
        services.AddSingleton(
            (s) => RestService.For<IFavoritesApi>(settings.HttpClient));

        services.AddTransient<IRatingsRepository, RatingsApiGateway>();
        services.AddTransient<IRecipeRepository, RecipeApiGateway>();
        services.AddTransient<IFavoritesRepository, FavoritesApiGateway>();

        return services;
    }
}
