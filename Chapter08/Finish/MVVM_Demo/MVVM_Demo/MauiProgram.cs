using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace MVVM_Demo;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();

        builder.Services.AddTransient<IQuoteService, QuoteService>();

        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<MainPage_MVVM>();

        Routing.RegisterRoute("about", typeof(AboutPage));
        builder.Services.AddTransient<AboutPage>();
        builder.Services.AddTransient<AboutPageViewModel>();

        builder.Services.AddTransientWithShellRoute<AboutPage, AboutPageViewModel>("about");

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}