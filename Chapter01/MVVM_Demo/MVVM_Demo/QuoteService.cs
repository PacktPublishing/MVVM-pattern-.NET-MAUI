namespace MVVM_Demo;

public interface IQuoteService
{
    Task<string> GetQuote();
}

public class QuoteService : IQuoteService
{
    private readonly HttpClient httpClient;

    public QuoteService()
    {
        httpClient = new HttpClient();
    }

    public async Task<string> GetQuote()
    {
        var response = await httpClient.GetAsync("https://my-quotes-api.com/quote-of-the-day");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        throw new Exception("Failed to retrieve quote.");
    }
}
