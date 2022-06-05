using System;

namespace GuiandoSupplier.Domain.Util
{
    public static class StringExtensions
    {
        public static string FormatCNPJ(this string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
