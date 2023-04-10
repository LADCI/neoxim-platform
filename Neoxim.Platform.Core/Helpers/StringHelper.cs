using System.Globalization;
using System.Text;

namespace Neoxim.Platform.Core.Helpers
{
    public static class StringHelper
    {
        public static string RemoveAccents(this string text)
        {
            StringBuilder sbReturn = new ();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
        public static string EfRemoveAccents(string text)
        {
            StringBuilder sbReturn = new ();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString().ToLower();
        }
    }
}