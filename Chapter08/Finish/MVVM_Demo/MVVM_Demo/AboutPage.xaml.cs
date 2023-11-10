using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Demo;

public partial class AboutPage : ContentPage, IQueryAttributable
{
	public AboutPage(AboutPageViewModel aboutPageViewModel)
	{
		InitializeComponent();
        this.BindingContext = aboutPageViewModel;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        lblParameter.Text = $"Parameter {query.First().Key}: {query.First().Value}";
    }
}


public class AboutPageViewModel : IQueryAttributable, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
    }
}