using MauiPrismSyncfusionTest.ViewModels;
using MauiPrismSyncfusionTest.ViewModels.Wizard;
using MauiPrismSyncfusionTest.Views;
using MauiPrismSyncfusionTest.Views.Wizard;

namespace MauiPrismSyncfusionTest;

internal static class PrismStartup
{
    public static void Configure(PrismAppBuilder builder)
    {
       builder.RegisterTypes(RegisterTypes)
            .CreateWindow($"{nameof(MasterDetailNavigation)}/{nameof(NavigationPage)}/{nameof(MainPage)}");
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MasterDetailNavigation, MasterDetailNavigationViewModel>();

        containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        containerRegistry.RegisterForNavigation<Page2, Page2ViewModel>();
        
        containerRegistry.RegisterForNavigation<Wizard, WizardViewModel>();
    }
}
