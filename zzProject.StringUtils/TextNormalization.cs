using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;

namespace zzProject.StringUtils.Core.Infrastructure.Text
{
    public class TextNormalization
    {
        public static string ToPascalCase(string text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            text = textInfo.ToTitleCase(text);
            return text;
        }

        public static string ToCamelCase(string text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            text = textInfo.ToTitleCase(text);
            for (int i = 0; i < text.Length; i++)
            {
                char current = text[i];
                if (char.IsLetter(current))
                {
                    text = text.Substring(0, i) + char.ToUpper(current) + text.Substring(i + 1, text.Length - i - 1);
                    break;
                }
            }
            return text;
        }

        public static string ToUpperCase(string text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            text = textInfo.ToUpper(text);
            return text;
        }

        public static string ToLowerCase(string text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            text = textInfo.ToLower(text);
            return text;
        }

        public static string RemoveDiacritics(string text)
        {
            //var normalizedString = text.Normalize(NormalizationForm.FormD);
            //var stringBuilder = new StringBuilder();

            //foreach (var c in normalizedString)
            //{
            //    var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            //    if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            //    {
            //        stringBuilder.Append(c);
            //    }
            //}

            //return stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            Regex nonSpacingMarkRegex = new Regex(@"\p{Mn}", RegexOptions.Compiled);
            return nonSpacingMarkRegex.Replace(text.Normalize(System.Text.NormalizationForm.FormD), String.Empty)
                            .Normalize(NormalizationForm.FormC);
        }

        public static string RemoveWordsFromPosition(string text, int position) {
            Regex nextWord = new Regex(@"\p", RegexOptions.Compiled);
            var match = nextWord.Match(text, position);
            return text.Substring(0, match.Index);
        }

        public static string RemoveWordsFromPosition(string text, int position, int maxLength) {
            Regex nextWord = new Regex(@"\p", RegexOptions.Compiled);
            var match = nextWord.Match(text, position, maxLength);
            return text.Substring(0, match.Index); 
        }
    }
}
