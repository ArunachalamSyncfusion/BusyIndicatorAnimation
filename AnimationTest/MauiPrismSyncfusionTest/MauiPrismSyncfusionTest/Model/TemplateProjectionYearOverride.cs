using System.Globalization;
using PropertyChanged;

namespace MauiPrismSyncfusionTest.Model
{

    [AddINotifyPropertyChangedInterface]
    public class TemplateProjectionYearOverride
    {

        #region Property Year

        public int Year
        {
            get;
            set;
        }

        #endregion

        #region Property Age

        public int Age
        {
            get;
            set;
        }

        #endregion

        #region Property Value

        public double Value
        {
            get;
            set;
        }

        #endregion

        #region Property Total

        public double Total
        {
            get;
            set;
        }

        #endregion

        #region Property TotalString

        public string TotalString
        {
            get
            {
                return $"{CultureInfo.InstalledUICulture.NumberFormat.CurrencySymbol}{Total}";
            }
           
        }

        #endregion

        #region Property Description

        public string Description
        {
            get;
            set;
        }

        #endregion

    }
}
