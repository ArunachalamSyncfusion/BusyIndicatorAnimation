using PropertyChanged;
using System.Globalization;
using System.Reflection;

namespace MauiPrismSyncfusionTest.ViewModels.Wizard.Template
{
    [AddINotifyPropertyChangedInterface]
    public class TemplateViewModelBase
    {

        #region Property ThumbnailText

        public string ThumbnailText
        {
            get;
            set;
        }

        #endregion

        #region Property ThumbnailImage

        private string _thumbnailImage;

        public string ThumbnailImage
        {
            get
            {
                return _thumbnailImage;
            }
            set
            {
                _thumbnailImage = value;
            }
        }

        #endregion;

        #region Property SelectedThumbnailImage

        private string _selectedThumbnailImage;

        public string SelectedThumbnailImage
        {
            get
            {
                return _selectedThumbnailImage;
            }
            set
            {
                _selectedThumbnailImage = value;
            }
        }

        #endregion;

        #region Property Culture

        public CultureInfo Culture
        {
            get
            {
                return new CultureInfo(CultureInfo.InstalledUICulture.Name);
            }
        }

        #endregion

        #region Property Template       

        private Grid _template;

        public Grid Template
        {
            get
            {
                _template = CreateTemplate(this);
                return _template;
                // Conditional break point "this.ThumbnailText=="User Details".
            }
        }

        #endregion;

        #region Property TemplatesAsXaml

        public Dictionary<string, string> TemplatesAsXaml
        {
            get;
            set;
        }

        #endregion

        public Grid CreateTemplate(TemplateViewModelBase templateViewModel)
        {
            string xamlTemplate = GetXamlTemplate(templateViewModel);
            Grid templateControlFromXaml = CreateTemplateControlFromXaml(xamlTemplate);

            templateControlFromXaml.BindingContext = templateViewModel;
            return templateControlFromXaml;
        }

        private string GetXamlTemplate(TemplateViewModelBase templateViewModel)
        {
            string templateViewName = GetTemplateViewName(templateViewModel);
            string templateXaml = string.Empty;

            if (TemplatesAsXaml != null)
            {
                templateXaml = GetTemplateAsXaml(templateViewName);
            }
            else
            {
                templateXaml = LoadTemplateFromEmbeddedResource(templateViewName, templateXaml);
            }


            return templateXaml;
        }

        private string GetTemplateViewName(TemplateViewModelBase templateViewModel)
        {
            string templateViewName = templateViewModel.GetType().ToString();
            int lastDot = templateViewName.LastIndexOf(".", StringComparison.Ordinal);
            int modelLength = 5;
            templateViewName =
                templateViewName.Substring(lastDot + 1, templateViewName.Length - 1 - lastDot - modelLength);
            return templateViewName;
        }

        private string GetTemplateAsXaml(string templateViewName)
        {
            string templateAsXaml;
            TemplatesAsXaml.TryGetValue(templateViewName, out templateAsXaml);
            return templateAsXaml;
        }

        private string LoadTemplateFromEmbeddedResource(string templateViewName, string templateXaml)
        {
            Assembly assembly = typeof(TemplateViewModelBase).GetTypeInfo().Assembly;
            Stream stream =
                 assembly.GetManifestResourceStream($"MauiPrismSyncfusionTest.Views.Wizard.Template.{templateViewName}.xaml");

            if (stream != null)
            {
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    templateXaml = reader.ReadToEnd();
                }
            }

            return templateXaml;
        }

        private Grid CreateTemplateControlFromXaml(string templateXaml)
        {
            Grid grid = new Grid();
            grid.LoadFromXaml(templateXaml);
            return grid;
        }   
    }
}
