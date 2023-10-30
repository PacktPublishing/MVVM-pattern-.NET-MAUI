namespace Recipes.Client.Repositories;

public class RepositorySettings
{
    public HttpClient HttpClient { get; }

    public RepositorySettings(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }
}
