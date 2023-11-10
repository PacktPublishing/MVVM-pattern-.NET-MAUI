using Recipes.Client.Core.ViewModels;
using Recipes.Mobile.TemplateSelectors;

namespace Recipes.Mobile.UnitTests;

public class InstructionsDataTemplateSelectorTests
{

    [Fact]
    public void SelectTemplate_NoteVM_Should_Return_NoteTemplate()
    {
        //Arrange
        var template = new DataTemplate();
        var sut = new InstructionsDataTemplateSelector();
        sut.NoteTemplate = template;
        sut.InstructionTemplate = new DataTemplate();

        //Act
        var result = sut.SelectTemplate(AutoFaker.Generate<NoteViewModel>(), null);

        //Assert
        Assert.Equal(template, result);
    }

    [Fact]
    public void SelectTemplate_InstructionVM_Should_Return_InstructionTemplate()
    {
        var sut = new InstructionsDataTemplateSelector();
        sut.NoteTemplate = new DataTemplate();
        sut.InstructionTemplate = new DataTemplate();

        var result = sut.SelectTemplate(AutoFaker.Generate<InstructionViewModel>(), null);
        Assert.Equal(sut.InstructionTemplate, result);
    }

    [Fact]
    public void SelectTemplate_RecipeDetailVM_Should_Return_Null()
    {
        var template1 = new DataTemplate();
        var template2 = new DataTemplate();
        var sut = new InstructionsDataTemplateSelector();
        sut.NoteTemplate = template1;
        sut.InstructionTemplate = template2;

        var result = sut.SelectTemplate(AutoFaker.Generate<RecipeDetailViewModel>(), null);
        Assert.Null(result);
    }
}