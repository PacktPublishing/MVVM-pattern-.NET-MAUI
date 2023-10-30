using Microsoft.AspNetCore.Mvc;
using Recipes.Shared.Dto;
using Recipes.Web.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();


app.MapGet("/recipes", (int pageSize, int pageIndex,
    [FromHeader(Name = "Accept-Language")] string language) =>
{
    //use language to retrieve recipes
    return new RecipeService()
        .LoadRecipes(pageSize, pageIndex);
})
.WithName("GetRecipes")
.WithOpenApi();


app.MapGet("/recipe/{id}", (string id) =>
{
    return new RecipeService().LoadRecipe(id);
})
.WithName("GetRecipe")
.WithOpenApi();

app.MapGet("/recipe/{id}/ratings", (string id) =>
{
    return new RatingsService().LoadRatings(id);
})
.WithName("GetRecipeRatings")
.WithOpenApi();

app.MapGet("/recipe/{id}/ratingssummary", (string id) =>
{
    return new RatingsService().LoadRatingsSummary(id);
})
.WithName("GetRecipeRatingsSummary")
.WithOpenApi();

app.MapGet("/users/{userId}/favorites", (string userId) =>
{
    return FavoritesDataStore.GetFavorites(userId);
})
.WithName("GetUserFavorites")
.WithOpenApi();

app.MapPost("/users/{userId}/favorites", (string userId, [FromBody] FavoriteDto favorite) =>
{
    FavoritesDataStore.StoreFavorite(userId, favorite);
})
.WithName("AddFavorite")
.WithOpenApi();

app.MapDelete("/users/{userId}/favorites/{recipeId}", (string userId, string recipeId) =>
{
    FavoritesDataStore.DeleteFavorite(userId, recipeId);
})
.WithName("DeleteFavorite")
.WithOpenApi();



app.Run();
