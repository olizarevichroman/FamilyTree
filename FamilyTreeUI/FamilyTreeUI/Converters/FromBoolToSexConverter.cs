using FamilyTreeLogic.DataLayer.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace FamilyTreeUI.Converters
{
  public class FromBoolToMaleSexConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return (Sex)value == Sex.Male;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return (bool)value == true ? Sex.Male : Sex.Female;
    }
  }

  public class FromBoolToFemaleSexConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return (Sex)value == Sex.Female;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return (bool)value == true ? Sex.Female : Sex.Male;
    }
  }
}
