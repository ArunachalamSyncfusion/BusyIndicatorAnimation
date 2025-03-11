using System.Collections.ObjectModel;
using System.Reflection;
using MauiPrismSyncfusionTest.Model;

namespace MauiPrismSyncfusionTest.ViewModels.Wizard.Template
{
    public class Template1ViewModel : TemplateViewModelBase
    {
        public Template1ViewModel()
        {   
            ThumbnailText = "Template 1";
            ThumbnailImage = "template1.png";
            SelectedThumbnailImage = "template1_selected.png";
                
            GenerateAdHocWithdrawals();
           
        }

        public ObservableCollection<TemplateProjectionYearOverride> AdHocWithdrawals
        {
            get;
            set;
        }

        public void GenerateAdHocWithdrawals()
        {
            AdHocWithdrawals = new ObservableCollection<TemplateProjectionYearOverride>();

            AdHocWithdrawals.Add(new TemplateProjectionYearOverride
            {
                Age = 1,
                Description = "Test",
                Total = 5000,
                Value = 2000,
                Year = 2020
            });
        }

    }
}
