
namespace MauiPrismSyncfusionTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        #region Command StartWizardCommand

        private DelegateCommand _startWizardCommand;

        public DelegateCommand StartWizardCommand =>
            _startWizardCommand ??= new DelegateCommand(ExecuteStartWizardCommandAsync);

        private async void ExecuteStartWizardCommandAsync()
        {
            IsBusy = true;
            await NavigateToWizardAsync();
            IsBusy = false;
        }

        #endregion
            
        private async Task NavigateToWizardAsync()
        {
            string navigationPageName = $"{nameof(NavigationPage)}/Wizard";

            NavigationParameters navigationParameters = new NavigationParameters
            {
                {
                    "Sketch", null
                },
                {
                    KnownNavigationParameters.UseModalNavigation, false
                },
                {
                    KnownNavigationParameters.Animated, true
                }
            };
            
            INavigationResult result = await NavigationService.NavigateAsync(navigationPageName, navigationParameters);
        }
    }
}
