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