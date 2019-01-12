using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FamilyTreeUI.Validation
{
  public class OnlyCharsValidationRule : ValidationRule
  {
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
      return (value ?? string.Empty).ToString().All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsSeparator(c))
        ? ValidationResult.ValidResult
        : new ValidationResult(false, "Field shoud contains only letters");
    }
  }
}
