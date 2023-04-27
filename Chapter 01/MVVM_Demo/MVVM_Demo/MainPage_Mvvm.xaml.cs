using System.ComponentModel;
using System.Windows.Input;

namespace MVVM_Demo;

public partial class MainPage_MVVM : ContentPage
{
    public MainPage_MVVM()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel(
            new QuoteService());
    }
}

public class MainPageViewModel : INotifyPropertyChanged
{
    readonly IQuoteService quoteService;

    private string quoteOfTheDay;

    public string QuoteOfTheDay
    {
        get => quoteOfTheDay;
        set
        {
            quoteOfTheDay = value;
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(QuoteOfTheDay)));
        }
    }

    private bool isButtonVisible = true;

    public bool IsButtonVisible
    {
        get => isButtonVisible;
        set
        {
            isButtonVisible = value;
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(IsButtonVisible)));
        }
    }

    bool isLabelVisible;
    public bool IsLabelVisible
    {
        get => isLabelVisible;
        set
        {
            isLabelVisible = value;
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(IsLabelVisible)));
        }
    }

    public ICommand GetQuoteCommand => new Command(async _ => await GetQuote());

    public MainPageViewModel(IQuoteService quoteService)
    {
        this.quoteService = quoteService;
    }

    private async Task GetQuote()
    {
        IsButtonVisible = false;

        try
        {
            var quote = await quoteService.GetQuote();

            QuoteOfTheDay = quote;

            IsLabelVisible = true;
        }
        catch (Exception)
        {
            //IsButtonVisible = true;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}

public interface IQuoteService
{
    Task<string> GetQuote();
}

public class QuoteService : IQuoteService
{
    public async Task<string> GetQuote()
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://my-quotes-api.com/quote-of-the-day");
        return await response.Content.ReadAsStringAsync();
    }
}
