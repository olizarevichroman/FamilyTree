using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FamilyTreeUI.Validation
{
  public class TextFieldLengthRangeValidationRule : ValidationRule
  {
    private readonly int _minimumLength = 2;

    private readonly int _maximumLength = 30; 
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
      var text = value.ToString();

      return text.Length >= _minimumLength && text.Length <= _maximumLength
        ? ValidationResult.ValidResult
        : new ValidationResult(false, $"Text length should be in range {_minimumLength}-{_maximumLength}");
    }
  }
}
