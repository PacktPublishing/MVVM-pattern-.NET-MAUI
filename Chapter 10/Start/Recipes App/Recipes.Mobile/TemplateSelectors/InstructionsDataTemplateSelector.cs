using Recipes.Client.Core.ViewModels;

namespace Recipes.Mobile.TemplateSelectors;

public class InstructionsDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate InstructionTemplate { get; set; }
    public DataTemplate NoteTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item is InstructionViewModel)
            return InstructionTemplate;
        else if(item is NoteViewModel)
            return NoteTemplate;

        return null;
    }
}
