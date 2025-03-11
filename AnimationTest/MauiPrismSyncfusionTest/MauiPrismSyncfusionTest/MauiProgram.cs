using CommunityToolkit.Maui;

namespace MauiPrismSyncfusionTest;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-brands-400.ttf", "FontAwesomeBrandsFont");
                fonts.AddFont("fa-regular-400.ttf", "FontAwesomeRegularFont");
                fonts.AddFont("fa-solid-900.ttf", "FontAwesomeSolidFont");
            });
        builder.UsePrism(PrismStartup.Configure);


        return builder.Build();
    }
}
