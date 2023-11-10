using System.Globalization;

namespace Recipes.Mobile.Converters;

public class InverseBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    => Inverse(value);

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    => Inverse(value);

    private bool Inverse(object value)
        => value switch
        {
            bool b => !b,
            _ => false
        };
}
