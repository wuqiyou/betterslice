using System;

namespace Slice.Core
{
    public static class StringHelper
    {
        public static string ConvertToFraction(string stringValue)
        {
            if (string.IsNullOrEmpty(stringValue) || stringValue.Trim().Equals("0"))
            {
                return string.Empty;
            }
            else if (stringValue.Contains("."))
            {
                var result = string.Empty;

                decimal numbericValue;
                decimal.TryParse(stringValue, out numbericValue);

                int wholeNumber = Math.Abs((int)Math.Floor(numbericValue));

                // If this fraction is greater than 1, we have to put the whole number first
                if (wholeNumber != 0)
                {
                    result += wholeNumber + " ";
                }

                // Now we do the fraction, if there is one.
                if (numbericValue - wholeNumber != 0)
                {
                    var fraction = string.Empty;
                    decimal remainder = Math.Round(numbericValue - wholeNumber, 3);

                    if (remainder == 0.5m)
                    {
                        fraction = "1/2";
                    }
                    else if (remainder == 0.333m || remainder == 0.667m || remainder == 0.33m || remainder == 0.66m)
                    {
                        fraction = (int)Math.Round(remainder * 3, 0) + "/3";
                    }
                    else if (remainder == 0.25m || remainder == 0.75m)
                    {
                        fraction = ((int)(remainder * 4)) + "/4";
                    }
                    else if (remainder == 0.2m || remainder == 0.4m || remainder == 0.6m || remainder == 0.8m)
                    {
                        fraction = ((int)(remainder * 5)) + "/5";
                    }
                    else if (remainder == 0.125m || remainder == 0.375m || remainder == 0.625m || remainder == 0.875m)
                    {
                        fraction = ((int)(remainder * 8)) + "/8";
                    }
                    else
                    {
                        fraction = Math.Round(remainder * 10, 0) + "/10";
                    }

                    result += FractionToHTML(fraction);
                }

                return result.Trim();
            }
            else
            {
                return FractionToHTML(stringValue);
            }
        }

        public static string FractionToHTML(string stringValue)
        {
            return stringValue

                .Replace("1/2", "&frac12;")

                .Replace("1/3", "&#8531;")
                .Replace("2/3", "&#8532;")

                .Replace("1/4", "&frac14;")
                .Replace("3/4", "&frac34;")

                .Replace("1/5", "&frac15;")
                .Replace("2/5", "&frac25;")
                .Replace("3/5", "&frac35;")
                .Replace("4/5", "&frac45;")

                .Replace("1/8", "&frac18;")
                .Replace("3/8", "&frac38;")
                .Replace("5/8", "&frac58;")
                .Replace("7/8", "&frac78;")

                .Replace("1/10", "&#8530;");
        }
    }
}
