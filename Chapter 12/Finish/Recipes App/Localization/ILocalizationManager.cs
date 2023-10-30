using System.Globalization;

namespace Localization;

public interface ILocalizationManager
{
    void RestorePreviousCulture(CultureInfo defaultCulture = null);
    void UpdateUserCulture(CultureInfo cultureInfo);
    CultureInfo GetUserCulture(CultureInfo defaultCulture = null);
}
