namespace Localization.Maui;

[ContentProperty(nameof(Key))]
public class TranslateExtension : IMarkupExtension<Binding>
{
    public string Key { get; set; }
   
    object IMarkupExtension.ProvideValue(
        IServiceProvider serviceProvider) 
        => ProvideValue(serviceProvider);

    public Binding ProvideValue(
        IServiceProvider serviceProvider)
        => new Binding
        {
            Mode = BindingMode.OneWay,
            Path = $"[{Key}]",
            Source = LocalizedResourcesProvider.Instance
        };
}
