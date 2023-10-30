using System.Globalization;

namespace Localization;

public interface ILocalizedResourcesProvider
{
    string this[string key]
    {
        get;
    }

    void UpdateCulture(CultureInfo cultureInfo);
}
