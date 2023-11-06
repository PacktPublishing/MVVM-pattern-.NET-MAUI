using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Recipes.Mobile.Controls;

public partial class FavoriteControlTemplated : ContentView
{
    public static readonly BindableProperty IsFavoriteProperty =
            BindableProperty.Create(nameof(IsFavorite), typeof(bool),
                typeof(FavoriteControlTemplated), defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: OnIsFavoriteChanged);

    private static void OnIsFavoriteChanged(BindableObject bindable, object oldValue, object newValue)
    => (bindable as FavoriteControlTemplated).AnimateChange();

    public static readonly BindableProperty ToggledCommandProperty =
        BindableProperty.Create(nameof(ToggledCommand),
            typeof(ICommand), typeof(FavoriteControlTemplated),
            propertyChanged: ToggledCommandChanged);

    private static void ToggledCommandChanged(
        BindableObject bindable, object oldValue, object newValue)
    {
        var control = bindable as FavoriteControlTemplated;

        if (oldValue is ICommand oldCommand)
        {
            oldCommand.CanExecuteChanged -= control.CanExecuteChanged;
        }

        if (newValue is ICommand newCommand)
        {
            newCommand.CanExecuteChanged += control.CanExecuteChanged;
        }

        control.UpdateIsInteractive();
    }

    public bool IsInteractive { get; private set; }

    private void CanExecuteChanged(object sender, EventArgs e)
        => UpdateIsInteractive();

    private void UpdateIsInteractive()
    {
        IsInteractive = IsEnabled
        && (ToggledCommand?.CanExecute(IsFavorite)
        ?? false);
        OnPropertyChanged(nameof(IsInteractive));
    }

    public bool IsFavorite
    {
        get { return (bool)GetValue(IsFavoriteProperty); }
        set { SetValue(IsFavoriteProperty, value); }
    }

    public ICommand ToggledCommand
    {
        get => (ICommand)GetValue(ToggledCommandProperty);
        set => SetValue(ToggledCommandProperty, value);
    }

    VisualElement scalableContent;

    public FavoriteControlTemplated()
    {
        InitializeComponent();
        if (ControlTemplate == null)
        {
            var template = Resources["DefaultTemplate"];
            ControlTemplate = template as ControlTemplate;
        }
    }

    protected override void OnPropertyChanged(
        [CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(IsEnabled))
        {
            UpdateIsInteractive();
        }
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        scalableContent =
            GetTemplateChild("scalableContent")
            as VisualElement;
    }

    private void TapGestureRecognizer_Tapped(
        object sender, TappedEventArgs e)
    {
        if (IsInteractive)
        {
            IsFavorite = !IsFavorite;
            ToggledCommand?.Execute(IsFavorite);
        }
    }

    private async Task AnimateChange()
    {
        if (scalableContent is not null)
        {
            await scalableContent.ScaleTo(1.5, 100);
            await scalableContent.ScaleTo(1, 100);
        }
    }
}