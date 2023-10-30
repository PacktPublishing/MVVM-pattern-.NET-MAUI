using Recipes.Client.Core.ViewModels;

namespace Recipes.Mobile;

public partial class PickLanguagePage : ContentPage
{
	public PickLanguagePage(PickLanguageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}