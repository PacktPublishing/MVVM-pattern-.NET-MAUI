namespace MVVM_Demo;

public partial class MainPage_MVVM : ContentPage
{
    public MainPage_MVVM(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
