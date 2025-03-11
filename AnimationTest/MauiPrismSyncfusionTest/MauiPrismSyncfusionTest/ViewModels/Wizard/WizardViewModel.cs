using System.Collections.ObjectModel;
using System.ComponentModel;
using MauiPrismSyncfusionTest.Model;
using MauiPrismSyncfusionTest.ViewModels.Wizard.Template;
using MauiPrismSyncfusionTest.Views;
using MiPlanMobile.Model.Extension;
using Prism.Navigation;

namespace MauiPrismSyncfusionTest.ViewModels.Wizard
{
    public class WizardViewModel : ViewModelBase
    {
        public WizardViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        #region Property WizardTemplates    

        private ObservableRangeCollection<TemplateViewModelBase> _wizardTemplates = new();

        public ObservableRangeCollection<TemplateViewModelBase> WizardTemplates
        {
            get => _wizardTemplates;    
            set => _wizardTemplates = value;
        }
            
        #endregion

        #region Property WizardIndex

        public int WizardIndex
        {
            get;
            set;
        }

        #endregion

        #region Property SelectorThumbnails

        private ObservableRangeCollection<SelectorThumbnail> _selectorThumbnails = new();

        public ObservableRangeCollection<SelectorThumbnail> SelectorThumbnails
        {
            get => _selectorThumbnails;
            set => _selectorThumbnails = value;
        }

        #endregion;

        #region Property SelectorSelectedItem

        public SelectorThumbnail SelectorSelectedItem
        {
            get;
            set;
        }

        #endregion

        #region Property SelectorScrollLeftIsVisible

        public bool SelectorScrollLeftIsVisible
        {
            get;
            set;
        }

        #endregion

        #region Property SelectorScrollRightIsVisible

        public bool SelectorScrollRightIsVisible
        {
            get;
            set;
        }

        #endregion

        #region Property ShowWizard

        public bool ShowWizard
        {
            get;
            set;
        }

        #endregion


        #region Command WizardSelectionChangedCommand

        private DelegateCommand<object> _wizardSelectionChangedCommand;

        public DelegateCommand<object> WizardSelectionChangedCommand => _wizardSelectionChangedCommand ??=
            new DelegateCommand<object>(ExecuteWizardSelectionChangedCommand);

        private async void ExecuteWizardSelectionChangedCommand(object param)
        {
            int index = System.Convert.ToInt32(param);
            SelectorSelectedItem = SelectorThumbnails[index];
        }

        #endregion

        #region Command SelectorItemTappedCommand

        private DelegateCommand<object> _selectorItemTappedCommand;

        public DelegateCommand<object> SelectorItemTappedCommand => _selectorItemTappedCommand ??=
            new DelegateCommand<object>(ExecuteSelectorItemTappedCommand);

        private void ExecuteSelectorItemTappedCommand(object param)
        {
            //Syncfusion.Maui.ListView.ItemTappedEventArgs eventArgs =
                //(Syncfusion.Maui.ListView.ItemTappedEventArgs) param;
            //SelectorThumbnail thumbnail = (SelectorThumbnail) eventArgs.DataItem;
            //if (thumbnail != null)
            //{
            //    WizardIndex = thumbnail.Index;
            //}
        }

        #endregion

        #region Command SelectorScrollLeftTappedCommand

        private DelegateCommand<object> _selectorScrollLeftTappedCommand;

        public DelegateCommand<object> SelectorScrollLeftTappedCommand => _selectorScrollLeftTappedCommand ??=
            new DelegateCommand<object>(ExecuteSelectorScrollLeftTappedCommand);

        private void ExecuteSelectorScrollLeftTappedCommand(object param)
        {
            if (SelectorSelectedItem.Index > 0)
            {
                SelectorSelectedItem = SelectorThumbnails[SelectorSelectedItem.Index - 1];
                WizardIndex = SelectorSelectedItem.Index;
            }
        }

        #endregion

        #region Command SelectorScrollRightTappedCommand

        private DelegateCommand<object> _selectorScrollRightTappedCommand;

        public DelegateCommand<object> SelectorScrollRightTappedCommand => _selectorScrollRightTappedCommand ??=
            new DelegateCommand<object>(ExecuteSelectorScrollRightTappedCommand);

        private void ExecuteSelectorScrollRightTappedCommand(object param)
        {
            if (SelectorSelectedItem.Index < SelectorThumbnails.Count - 1)
            {
                SelectorSelectedItem = SelectorThumbnails[SelectorSelectedItem.Index + 1];
                WizardIndex = SelectorSelectedItem.Index;
            }
        }

        #endregion

        #region Command CloseWizardCommand

        private DelegateCommand _closeWizardCommand;

        public DelegateCommand CloseWizardCommand =>
            _closeWizardCommand ??= new DelegateCommand(ExecuteCloseWizardCommand);

        private async void ExecuteCloseWizardCommand()
        {
            string navigationPageName = $"{nameof(NavigationPage)}/{nameof(MainPage)}";
            await NavigationService.NavigateAsync(navigationPageName);
        }

        #endregion

        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            ShowWizard = false;
            IsBusy = true;

            await Task.Delay(500);
            
            await LoadFlow1TemplatesAsync();
            await CreateSelectorThumbnailsAsync(0);
            ShowWizard = true;
            IsBusy = false;
        }   

        private async Task LoadFlow1TemplatesAsync()
        {
            IsBusy = true;

            MessagingCenter.Unsubscribe<Template2ViewModel>(this, "LoadTemplates1");
            MessagingCenter.Unsubscribe<Template2ViewModel>(this, "LoadTemplates2");

            List<TemplateViewModelBase> templates = new();

            await Task.Run(async () =>
            {
                SketchTypeViewModel sketchTypeViewModel = new();
                templates.Add(sketchTypeViewModel);
                    
                Template1ViewModel template1ViewModel = new();
                templates.Add(template1ViewModel);

                Template2ViewModel template2ViewModel = new();
                templates.Add(template2ViewModel);

                Template3ViewModel template3ViewModel = new();
                templates.Add(template3ViewModel);

                Template4ViewModel template4ViewModel = new();
                templates.Add(template4ViewModel);

                Template1ViewModel template5ViewModel = new();
                templates.Add(template5ViewModel);

                Template2ViewModel template6ViewModel = new();
                templates.Add(template6ViewModel);

                Template3ViewModel template7ViewModel = new();
                templates.Add(template7ViewModel);

                Template4ViewModel template8ViewModel = new();
                templates.Add(template8ViewModel);

                Template1ViewModel template9ViewModel = new();
                templates.Add(template9ViewModel);

                Template2ViewModel template10ViewModel = new();
                templates.Add(template10ViewModel);

                Template3ViewModel template11ViewModel = new();
                templates.Add(template11ViewModel);

                Template4ViewModel template12ViewModel = new();
                templates.Add(template12ViewModel);

                Template1ViewModel template13ViewModel = new();
                templates.Add(template13ViewModel);

                Template2ViewModel template14ViewModel = new();
                templates.Add(template14ViewModel);

                Template3ViewModel template15ViewModel = new();
                templates.Add(template15ViewModel);

                Template4ViewModel template16ViewModel = new();
                templates.Add(template16ViewModel);

                Template1ViewModel template17ViewModel = new();
                templates.Add(template17ViewModel);

                Template2ViewModel template18ViewModel = new();
                templates.Add(template18ViewModel);

                Template3ViewModel template19ViewModel = new();
                templates.Add(template19ViewModel);

                Template4ViewModel template20ViewModel = new();
                templates.Add(template20ViewModel);

                Template1ViewModel template21ViewModel = new();
                templates.Add(template21ViewModel);

                Template2ViewModel template22ViewModel = new();
                templates.Add(template22ViewModel);

                Template3ViewModel template23ViewModel = new();
                templates.Add(template23ViewModel);

                Template4ViewModel template24ViewModel = new();
                templates.Add(template24ViewModel);

                //Uncomment below to make Windows obvious - our app has Templates that are more demanding so we dont have this many but get the same result.

                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
                //templates.Add(template1ViewModel);
            });

            _wizardTemplates.ReplaceRange(templates);
            
            await CreateSelectorThumbnailsAsync(0);

            WizardIndex = 0;
            SelectorSelectedItem = SelectorThumbnails[0];

            MessagingCenter.Subscribe<Template2ViewModel>(this, "LoadFlow2", async (sender) =>
            {
                await LoadFlow2TemplatesAsync(sender);
            });

            IsBusy = false;
        }

        private async Task LoadFlow2TemplatesAsync(Template2ViewModel sender)
        {
            IsBusy = true;
            MessagingCenter.Unsubscribe<Template2ViewModel>(this, "LoadFlow1");
            MessagingCenter.Unsubscribe<Template2ViewModel>(this, "LoadFlow2");

            List<TemplateViewModelBase> templates = new();

            await Task.Run(() =>
            {
                Template2ViewModel template2ViewModel = new();
                Template3ViewModel template3ViewModel = new();

                templates.Add(template2ViewModel);
                templates.Add(template3ViewModel);
            });

            _wizardTemplates.ReplaceRange(templates);
            await CreateSelectorThumbnailsAsync(0);

            WizardIndex = 0;
            SelectorSelectedItem = SelectorThumbnails[0];

            MessagingCenter.Subscribe<Template2ViewModel>(this, "LoadFlow1", async (sender) =>
            {
                await LoadFlow1TemplatesAsync();
            });

            IsBusy = false;
        }

        private async Task CreateSelectorThumbnailsAsync(int index)
        {
            List<SelectorThumbnail> thumbnails = new();

            await Task.Run(() =>
            {
                for (int iTemplate = 0; iTemplate < WizardTemplates.Count; iTemplate++)
                {
                    TemplateViewModelBase template = (TemplateViewModelBase) WizardTemplates[iTemplate];

                    SelectorThumbnail thumbnail = new()
                    {
                        Index = iTemplate,
                        Text = template.ThumbnailText,
                        Image = template.ThumbnailImage,
                        SelectedImage = template.SelectedThumbnailImage
                    };

                    thumbnails.Add(thumbnail);
                }
            });

            SelectorThumbnails.ReplaceRange(thumbnails);
            SelectorSelectedItem = SelectorThumbnails[index];
        }

        private void MoveToWizardIndex(string shortcutPage)
        {
            foreach (TemplateViewModelBase templateViewModelBase in _wizardTemplates)
            {
                Type type = templateViewModelBase.GetType();
                string stringType = type.ToString();

                stringType = stringType.Substring(stringType.LastIndexOf('.') + 1);

                if (stringType == shortcutPage)
                {
                    int index = _wizardTemplates.IndexOf(templateViewModelBase);
                    WizardIndex = index;
                    SelectorSelectedItem = SelectorThumbnails[WizardIndex];
                }
            }
        }
    }
}
