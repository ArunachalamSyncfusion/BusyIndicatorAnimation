namespace MauiPrismSyncfusionTest.ViewModels.Wizard.Template
{
    public class Template2ViewModel : TemplateViewModelBase
    {

        public Template2ViewModel()
        {
            ThumbnailText = "Template 2";
            ThumbnailImage = "template2.png";
            SelectedThumbnailImage = "template2_selected.png";

        }

        #region Command LoadFlow1TemplatesButtonPressedCommand

        private DelegateCommand _loadFlow1TemplatesButtonPressedCommand;

        public DelegateCommand LoadFlow1TemplatesButtonPressedCommand => _loadFlow1TemplatesButtonPressedCommand ??= new DelegateCommand(ExecuteLoadFlow1TemplatesButtonPressedCommand);

        private void ExecuteLoadFlow1TemplatesButtonPressedCommand()
        {
            MessagingCenter.Send(this, "LoadFlow1");
        }

        #endregion

        #region Command LoadFlow2TemplatesButtonPressedCommand

        private DelegateCommand _loadFlow2TemplatesButtonPressedCommand;

        public DelegateCommand LoadFlow2TemplatesButtonPressedCommand => _loadFlow2TemplatesButtonPressedCommand ??= new DelegateCommand(ExecuteLoadFlow2TemplatesButtonPressedCommand);

        private void ExecuteLoadFlow2TemplatesButtonPressedCommand()
        {
            MessagingCenter.Send(this, "LoadFlow2");
        }

        #endregion


    }
}
