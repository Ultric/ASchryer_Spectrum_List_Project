using System;
using System.Globalization;
using Xamarin.Forms;

namespace ASchryer_Spectrum_List_Project.Converters
{
    public class GenderToBorderColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gender = value as string;
            if (gender == null)
                return null;

            if (gender == "male")
                return Color.Aqua;
            else if (gender == "female")
                return Color.Crimson;

            return Color.LemonChiffon;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
