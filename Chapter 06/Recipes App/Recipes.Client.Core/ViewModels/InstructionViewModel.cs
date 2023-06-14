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

public class InstructionBaseViewModel { }

public class NoteViewModel : InstructionBaseViewModel
{
    public string Note { get; }
    public NoteViewModel(string note)
        => Note = note;
}