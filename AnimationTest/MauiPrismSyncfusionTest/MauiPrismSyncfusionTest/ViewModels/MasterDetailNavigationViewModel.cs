using System.Collections.ObjectModel;
using MauiPrismSyncfusionTest.Views;
using PropertyChanged;
using MenuItem = MauiPrismSyncfusionTest.Model.MenuItem;

namespace MauiPrismSyncfusionTest.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MasterDetailNavigationViewModel
    {
        #region Initialisation

        private INavigationService _navigationService;

        public MasterDetailNavigationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            CreateMenuItems();
        }

        #endregion
        
        #region Property MenuItems

        public ObservableCollection<MenuItem> MenuItems
        {
            get;
            set;
        }

        #endregion

        #region Property SelectedMenuItem

        public MenuItem SelectedMenuItem
        {
            get;
            set;
        }

        #endregion

        #region Command NavigateCommand

        private DelegateCommand _navigateCommand;

        public DelegateCommand NavigateCommand =>
            _navigateCommand ??= new DelegateCommand(ExecuteNavigateCommand);

        async void ExecuteNavigateCommand()
        {
            string navigationPageName = $"{nameof(NavigationPage)}/{SelectedMenuItem.PageTitle}";
            await _navigationService.NavigateAsync(navigationPageName);
        }

        #endregion
        
        private void CreateMenuItems()
        {   
            Application.Current.Resources.TryGetValue("HomeMenuIcon", out object homeMenuIcon); 
            Application.Current.Resources.TryGetValue("SettingsMenuIcon", out object settingsMenuIcon);
            
            MenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    PageTitle = nameof(MainPage),
                    MenuIcon =  homeMenuIcon,
                    MenuText = "MainPage"
                },
                new MenuItem
                {
                    PageTitle = nameof(Page2),
                    MenuIcon = settingsMenuIcon,
                    MenuText = "Page2"
                }
            };

            SelectedMenuItem = MenuItems[0];
        }



    }
}
