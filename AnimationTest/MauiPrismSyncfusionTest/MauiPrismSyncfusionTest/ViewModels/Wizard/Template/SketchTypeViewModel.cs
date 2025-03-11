using CommunityToolkit.Mvvm.Messaging;

namespace MauiPrismSyncfusionTest.ViewModels.Wizard.Template
{
    public class SketchTypeViewModel : TemplateViewModelBase
    {
        #region Initialisation

        public SketchTypeViewModel()
        {
            ThumbnailText = "Template 1";
            ThumbnailImage = "template1.png";
            SelectedThumbnailImage = "template1_selected.png";
        }

        #endregion

        #region Property SolverSelected

        private bool _solverSelected = true;

        public bool SolverSelected
        {
            get
            {
                return _solverSelected;
            }
            set
            {
                _solverSelected = value;
            }
        }

        #endregion

        #region Property SolverImage

        private string _solverImage;

        public string SolverImage
        {
            get
            {
                if (SolverSelected)
                {
                    _solverImage = "solver_gold_transparent";
                }
                else
                {
                    _solverImage = "solver_white_transparent";
                }
                _solverImage = $"{_solverImage}.png";
                return _solverImage;
            }
        }

        #endregion

        #region Property ExistingAssetsSelected

        public bool ExistingAssetsSelected
        {
            get;
            set;
        }

        #endregion

        #region Property ExistingAssetsImage

        private string _existingAssetsImage;

        public string ExistingAssetsImage
        {
            get
            {
                if (ExistingAssetsSelected)
                {
                    _existingAssetsImage = "existingassets_gold_transparent";
                }
                else
                {
                    _existingAssetsImage = "existingassets_white_transparent";
                }
                _existingAssetsImage = $"{_existingAssetsImage}.png";
                return _existingAssetsImage;
            }
        }

        #endregion

        #region Property SolverWithExistingAssetsSelected

        public bool SolverWithExistingAssetsSelected
        {
            get;
            set;
        }

        #endregion

        #region Property SolverWithExistingAssetsImage

        private string _solverWithExistingAssetsImage;

        public string SolverWithExistingAssetsImage
        {
            get
            {
                if (SolverWithExistingAssetsSelected)
                {
                    _solverWithExistingAssetsImage = "solverwithexistingassets_gold_transparent";
                }
                else
                {
                    _solverWithExistingAssetsImage = "solverwithexistingassets_white_transparent";
                }
                _solverWithExistingAssetsImage = $"{_solverWithExistingAssetsImage}.png";
                return _solverWithExistingAssetsImage;
            }
        }

        #endregion

        #region Property RetirementSelected

        public bool RetirementSelected
        {
            get;
            set;
        }

        #endregion

        #region Property RetirementImage

        private string _retirementImage;

        public string RetirementImage
        {
            get
            {
                if (RetirementSelected)
                {
                    _retirementImage = "retirement_gold_transparent";
                }
                else
                {
                    _retirementImage = "retirement_white_transparent";
                }
                _retirementImage = $"{_retirementImage}.png";
                return _retirementImage;
            }
        }

        #endregion

    }
}
