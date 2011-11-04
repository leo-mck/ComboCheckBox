

namespace ComboCheckBox
{
    using System;
    using System.Windows.Data;
    using System.Collections;
    using System.Linq;
    using System.Collections.Generic;


    public class CheckedItemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var col = value as IEnumerable<CheckItem>;
            if (col != null)
            {
                var txt = String.Join("," , col.Where(c=>c.IsChecked == true).Select(c=>c.Text));
                return txt;
            }
            return null;
        }

     
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();            
        }        
    }
}
