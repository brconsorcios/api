using System.IO;
using System;

namespace BrConsorcio.Api.Helpers
{
    public static class Date
    {
        public static DateTime DateFormat(string value, string format)
        {
            try
            {
                DateTime data;
                DateTime.TryParseExact(value, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out data);
                if (data == null || data == DateTime.MinValue)
                    DateTime.TryParseExact(value, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out data);
                if (data == null || data == DateTime.MinValue)
                    throw new InvalidDataException("Data inválida");

                return data;
            }
            catch
            {
                throw new InvalidDataException("Data inválida");
            }
        }
    }
}
