using CommunityToolkit.Mvvm.ComponentModel;
using System.Globalization;
using System.Resources;

namespace Localization;

public class LocalizedResourcesProvider : ObservableObject, ILocalizedResourcesProvider
{
    ResourceManager resourceManager;

    CultureInfo currentCulture;

    public static LocalizedResourcesProvider Instance
    {
        get;
        private set;
    }

    public string this[string key]
        => resourceManager.GetString(key, currentCulture)
        ?? key;

    public LocalizedResourcesProvider(ResourceManager resourceManager)
    {
        this.resourceManager = resourceManager;
        currentCulture = CultureInfo.CurrentUICulture;
        Instance = this;
    }

    public void UpdateCulture(CultureInfo cultureInfo)
    {
        currentCulture = cultureInfo;
        OnPropertyChanged("Item");
    }
}
