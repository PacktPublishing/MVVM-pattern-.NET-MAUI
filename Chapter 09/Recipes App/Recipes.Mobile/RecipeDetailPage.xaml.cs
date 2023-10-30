using Recipes.Client.Core.ViewModels;

namespace Recipes.Mobile;
public partial class RecipeDetailPage : ContentPage
{
    IDialogService dialogService;
    public RecipeDetailPage(RecipeDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        dialogService = new DialogService();
        DoStuff();
    }
    
    private async Task DoStuff()
    {
        await Task.Delay(1000);

        var r = await dialogService.AskYesNo("Yes or no?", "tell me, yes or no");
        await dialogService.Notify("result", r.ToString());
var r2 = await dialogService.Ask("enter some text", "please do");
await dialogService.Notify("result", r2);

var r3 = await dialogService.Ask("please do not enter text", "please do");
await dialogService.Notify("result", r3 ?? "null");

var r4 = await dialogService.Ask("please do not enter text", "please do");
await dialogService.Notify("result", r4 ?? "null");
        //Application.Current.MainPage.DisplayAlert("hello", "ok", "nok");
    }
}

public interface IDialogService
{
    Task Notify(string title, string message, string buttonText = "OK");
    Task<bool> AskYesNo(string title, string message, string trueButtonText = "Yes", string falseButtonText = "No");
    Task<string?> Ask(string title, string message, string acceptButtonText = "OK", string cancelButtonText = "Cancel");
}


public class DialogService : IDialogService
{
    public Task Notify(string title, string message, string buttonText = "OK")
        => Application.Current.MainPage.DisplayAlert(title, message, buttonText);

    public Task<bool> AskYesNo(string title, string message, string trueButtonText = "Yes", string falseButtonText = "No")
        => Application.Current.MainPage.DisplayAlert(title, message, trueButtonText, falseButtonText);
    
    public Task<string?> Ask(string title, string message, string acceptButtonText = "OK", string cancelButtonText = "Cancel")
        => Application.Current.MainPage.DisplayPromptAsync(title, message, acceptButtonText, cancelButtonText);
}