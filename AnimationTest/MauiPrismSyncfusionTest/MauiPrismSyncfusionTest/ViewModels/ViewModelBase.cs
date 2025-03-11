using PropertyChanged;

namespace MauiPrismSyncfusionTest.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        protected INavigationService NavigationService
        {
            get;
            set;
        }

        #region Property IsBusy

        public bool IsBusy
        {
            get;
            set;
        }

        #endregion
        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }
    }
}
