namespace Recipes.Client.Core.ViewModels;

public class InstructionViewModel
{
    public int Index { get; }

    public int DisplayIndex { get => Index + 1; }

    public string Description { get; }

    public InstructionViewModel(int index, string description)
    {
        Index = index;
        Description = description;
    }
}