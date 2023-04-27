namespace MVVM_Demo;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        GetQuoteButton.IsVisible = false;

        try
        {
            var client = new HttpClient();

            var response = await
                client.GetAsync(
                "https://my-quotes-api.com/quote-of-the-day");

            var quote = await
                response.Content.ReadAsStringAsync();

            QuoteLabel.Text = quote;

            QuoteLabel.IsVisible = true;
        }
        catch (Exception)
        {
        }
    }
}

