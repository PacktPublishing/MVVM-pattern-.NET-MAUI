using CommunityToolkit.Mvvm.Messaging.Messages;
using System.Globalization;

namespace Recipes.Client.Core.Messages;

public class CultureChangedMessage :
ValueChangedMessage<CultureInfo>
{
    public CultureChangedMessage(CultureInfo value) :
        base(value)
    { }
}
