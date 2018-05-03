﻿// This source is subject to the MIT License.
// Please see https://github.com/frederiksen/Task-Card-Creator for details.
// All other rights reserved.

using System;
using System.Globalization;
using System.Windows.Data;
using ReportInterface;

namespace NBSAgile.Converters
{
  class UnknownTypeConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      try
      {
        var workItem = value as ReportItem;
        if (workItem != null)
        {
            string header = string.Empty;
            if (workItem.Type != null)
            {
                header += workItem.Type;
                header += " ";
                header += workItem.Id;
                return header;
            }

         return "-";
        }
        return "Error: Incorrect type";
      }
      catch (Exception exception)
      {
        return string.Format("Error: {0}", exception.Message);
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
