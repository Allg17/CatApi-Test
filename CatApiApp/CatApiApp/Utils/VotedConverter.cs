using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace CatApiApp.Utils
{
    public class VotedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    if (value.Toint() == 1)
                    {
                        return "Cat Liked!";
                    }
                    else
                    {
                        return "Cat not liked!";
                    }
                }
                else
                    return "Cat not liked!";
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message, "Error!", "Ok");
                return "Cat not liked!";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
