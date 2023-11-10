using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Recipes.Client.Core.Messages;

public class ServingsChangedMessage : ValueChangedMessage<int>
{
    public ServingsChangedMessage(int value) : base(value)
    { }
}
