using System;
using System.Linq;
using System.Reflection;
using DryIoc.ImTools;
using PropertyChanged;


namespace MauiPrismSyncfusionTest.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class Page2ViewModel : ViewModelBase
    {
        private int _contentsCounter = 1;

        public Page2ViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        #region Property LabelText

        private string _labelText = ".............";

        public string LabelText
        {
            get
            {
                return _labelText;
            }
            set
            {
                _labelText = value;
            }
        }

        #endregion

        #region Command ExecuteSaveCommand

        private DelegateCommand _saveCommand;

        public DelegateCommand SaveCommand =>
            _saveCommand ??= new DelegateCommand(ExecuteSaveCommand);

        private async void ExecuteSaveCommand()
        {
            string pathAndFileName = GetPathAndFileName();
            string fileText = $"Hello Mark... [{_contentsCounter}]";

            FileStream fileStream = null;

            using (fileStream = File.Create(pathAndFileName))
            using (StreamWriter streamWriter = new(fileStream))
            {
                await streamWriter.WriteAsync(fileText);
            }

            fileStream?.Dispose();
            LabelText = "File saved";
            _contentsCounter++;
        }

        #endregion

        #region Command ReadCommand

        private DelegateCommand _readCommand;

        public DelegateCommand ReadCommand => _readCommand ??= new DelegateCommand(ExecuteReadCommand);

        private async void ExecuteReadCommand()
        {
            LabelText = "Reading...";
            string pathAndFileName = GetPathAndFileName();

            using (FileStream fileStream = File.OpenRead(pathAndFileName))

            using (StreamReader streamReader = new(fileStream))
            {
                streamReader.BaseStream.Position = 0;
                LabelText = await streamReader.ReadToEndAsync();
            }
        }

        #endregion

        private string GetPathAndFileName()
        {
            string documentsPath =
                $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}/MiPlanMobile/Test";

            if (!Directory.Exists(documentsPath))
            {
                Directory.CreateDirectory(documentsPath);
            }

            string pathAndFileName = $"{documentsPath}/Test.txt";
            return pathAndFileName;
        }

    }
}
