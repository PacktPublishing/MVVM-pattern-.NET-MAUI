using Recipes.Client.Core.Services;

namespace Recipes.Mobile.Services
{
    public class DialogService : IDialogService
    {
        public Task Notify(string title, string message, string buttonText = "OK")
            => Application.Current.MainPage.DisplayAlert(title, message, buttonText);

        public Task<bool> AskYesNo(string title, string message, string trueButtonText = "Yes", string falseButtonText = "No")
            => Application.Current.MainPage.DisplayAlert(title, message, trueButtonText, falseButtonText);

        public Task<string?> Ask(string title, string message, string acceptButtonText = "OK", string cancelButtonText = "Cancel")
            => Application.Current.MainPage.DisplayPromptAsync(title, message, acceptButtonText, cancelButtonText);
    }
}
