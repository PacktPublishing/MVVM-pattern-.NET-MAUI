using Recipes.Client.Core.Navigation;
using Recipes.Mobile.Navigation;

namespace Recipes.Mobile;


public partial class AppShell : Shell
{
    INavigationInterceptor interceptor;

    public AppShell(INavigationInterceptor interceptor)
    {
        this.interceptor = interceptor;
        InitializeComponent();
        
    }

    protected override async void OnNavigated(ShellNavigatedEventArgs args)
    {
        var navigationType = GetNavigationType(args.Source);

        base.OnNavigated(args);

        await interceptor.OnNavigatedTo(
            CurrentPage?.BindingContext, navigationType);
    }

    //protected override async void OnNavigating(ShellNavigatingEventArgs args)
    //{
    //    ShellNavigatingDeferral token = args.GetDeferral();

    //    var navigationType = GetNavigationType(args.Source);

    //    var canNavigate = await shellNavigationInterceptor.CanNavigate(CurrentPage?.BindingContext, navigationType);

    //    if (!canNavigate)
    //    {
    //        args.Cancel();
    //    }
    //    else
    //    {
    //        await shellNavigationInterceptor.OnNavigating(CurrentPage?.BindingContext, GetNavigationType(args.Source));
    //    }

    //    token?.Complete();


    //    base.OnNavigating(args);
    //}

    //protected override async void OnNavigating(ShellNavigatingEventArgs args)
    //{
    //    ShellNavigatingDeferral token = args.GetDeferral();
    //    var navigationType = GetNavigationType(args.Source);

    //    await shellNavigationInterceptor.OnNavigatingFrom(CurrentPage?.BindingContext, navigationType);

    //    token?.Complete();
    //}



    //private NavigationType GetNavigationType(ShellNavigationSource source)
    //    => source switch
    //    {
    //        ShellNavigationSource.Unknown => NavigationType.Unknown,
    //        ShellNavigationSource.Push => NavigationType.Forward,
    //        ShellNavigationSource.Pop => NavigationType.Back,
    //        ShellNavigationSource.PopToRoot => NavigationType.Back,
    //        ShellNavigationSource.Insert => NavigationType.Forward,
    //        ShellNavigationSource.Remove => NavigationType.Back, 
    //        ShellNavigationSource.ShellItemChanged => NavigationType.SectionChange,
    //        ShellNavigationSource.ShellSectionChanged => NavigationType.SectionChange,
    //        ShellNavigationSource.ShellContentChanged => NavigationType.SectionChange,
    //        _ => NavigationType.Unknown,
    //    };

    private NavigationType GetNavigationType(ShellNavigationSource source) =>
    source switch
    {
        ShellNavigationSource.Push or 
        ShellNavigationSource.Insert 
            => NavigationType.Forward,
        ShellNavigationSource.Pop or 
        ShellNavigationSource.PopToRoot or 
        ShellNavigationSource.Remove 
            => NavigationType.Back,
        ShellNavigationSource.ShellItemChanged or 
        ShellNavigationSource.ShellSectionChanged or 
        ShellNavigationSource.ShellContentChanged 
            => NavigationType.SectionChange,
        _ => NavigationType.Unknown
    };
}