using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Recipes.Client.Core.Favorites;
using Recipes.Client.Core.Navigation;
using Recipes.Client.Core.Ratings;
using Recipes.Client.Core.Recipes;
using Recipes.Client.Core.ViewModels;
using Recipes.Mobile.Navigation;
//using Recipes.Mobile.Navigation;

namespace Recipes.Mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIconsRegular");
            });
		builder.UseMauiCommunityToolkit();


		builder.Services.AddTransient<RecipesOverviewPage>();
		builder.Services.AddTransient<RecipesOverviewViewModel>();

		builder.Services.AddTransient<RecipeDetailPage>();
		builder.Services.AddTransient<RecipeDetailViewModel>();
        
		builder.Services.AddTransient<RecipeRatingDetailPage>();
        builder.Services.AddTransient<RecipeRatingsDetailViewModel>();

        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<SettingsViewModel>();

        builder.Services.AddTransient<AddRatingPage>();
        builder.Services.AddTransient<AddRatingViewModel>();

        builder.Services.AddSingleton<IFavoritesService, FavoritesService>();


        builder.Services.AddSingleton<IRatingsService>(
            serviceProvider => new RatingsService(FileSystem.OpenAppPackageFileAsync("ratings.json")));

		builder.Services.AddTransient<IRecipeService>(
            serviceProvider => new RecipeService(FileSystem.OpenAppPackageFileAsync("recipedetails.json")));

		builder.Services.AddTransient<LoginPageViewModel>();

        //Shell
        builder.Services.AddSingleton<NavigationService>();

        builder.Services.AddSingleton<INavigationService>(
            c => c.GetRequiredService<NavigationService>());

        builder.Services.AddSingleton<INavigationInterceptor>(
            c => c.GetRequiredService<NavigationService>());
        Routing.RegisterRoute("Overview", typeof(RecipesOverviewPage));
        Routing.RegisterRoute("RecipeDetail", typeof(RecipeDetailPage));
        Routing.RegisterRoute("RecipeRating", typeof(RecipeRatingDetailPage));
        Routing.RegisterRoute("AddRating", typeof(AddRatingPage));
        //Shell


        //Non-Shell
        //builder.Services.AddSingleton<INavigationService, NonShellNavigationService>();

        //Routes.Register<RecipesOverviewPage>("Overview");
        //Routes.Register<RecipeDetailPage>("RecipeDetail");
        //Routes.Register<RecipeRatingDetailPage>("RecipeRating");
        //Non-Shell

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
