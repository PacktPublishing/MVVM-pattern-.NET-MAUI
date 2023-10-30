namespace Recipes.Client.Core.ViewModels;

public class NoteViewModel : InstructionBaseViewModel
{
    public string Note { get; }
    public NoteViewModel(string note)
        => Note = note;
}