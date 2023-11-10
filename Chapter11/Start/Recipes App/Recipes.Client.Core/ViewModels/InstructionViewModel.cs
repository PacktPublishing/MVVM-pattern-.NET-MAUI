namespace Recipes.Client.Core.ViewModels;

public class InstructionViewModel : InstructionBaseViewModel
{
    public int Index { get; }

    public string Description { get; }

    public InstructionViewModel(int index, string description)
    {
        Index = index;
        Description = description;
    }
}
