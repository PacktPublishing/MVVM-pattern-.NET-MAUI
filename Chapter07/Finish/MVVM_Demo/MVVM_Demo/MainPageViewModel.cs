using System.ComponentModel;
using System.Windows.Input;

namespace MVVM_Demo;

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
            IsButtonVisible = true;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
