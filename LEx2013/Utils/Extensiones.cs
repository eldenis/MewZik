using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MewZik.Utils
{
    public static class Extensiones
    {

        public static string RemoveDiacritics(this string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            return string.Concat(text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark))
                .Normalize(NormalizationForm.FormC);
        }

        public static bool EsNuloOVacio<T>(this IList<T> lista)
        {
            return lista == null || lista.Count == 0;
        }
    }
}
