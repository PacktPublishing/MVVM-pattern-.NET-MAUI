using System.Globalization;

namespace Localization.Maui;


public class LocalizationManager : ILocalizationManager
{
    readonly ILocalizedResourcesProvider _resourceProvider;

    private CultureInfo currentCulture;

    public LocalizationManager(ILocalizedResourcesProvider resoureProvider)
    {
        _resourceProvider = resoureProvider;
    }

    public void RestorePreviousCulture(CultureInfo defaultCulture = null)
        => SetCulture(GetUserCulture(defaultCulture));

    public CultureInfo GetUserCulture(CultureInfo defaultCulture = null)
    {
        if (currentCulture is null)
        {
            var culture = Preferences.Default.Get("UserCulture", string.Empty);
            if (string.IsNullOrEmpty(culture))
            {
                currentCulture = defaultCulture ?? CultureInfo.CurrentCulture;
            }
            else
            {
                currentCulture = new CultureInfo(culture);
            }
        }
        return currentCulture;
    }

    public void UpdateUserCulture(CultureInfo cultureInfo)
    {
        Preferences.Default.Set("UserCulture", cultureInfo.Name);
        SetCulture(cultureInfo);
    }

    private void SetCulture(CultureInfo cultureInfo)
    {
        currentCulture = cultureInfo;
        Application.Current.Dispatcher.Dispatch(() =>
        {
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        });
        _resourceProvider.UpdateCulture(cultureInfo);
    }
}
