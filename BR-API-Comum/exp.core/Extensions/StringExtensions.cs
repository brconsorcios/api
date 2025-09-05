using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace exp.core
{
    public static class StringExtensions
    {
        public static string ToSlug(this string text)
        {
            return ToSlug(text, null);
        }

        public static string ToSlug(this string text, string separator)
        {
            text = string.IsNullOrWhiteSpace(text) ? string.Empty : text;
            separator = string.IsNullOrWhiteSpace(separator) ? "-" : separator;

            var value = text.Normalize(NormalizationForm.FormD).Trim();
            var builder = new StringBuilder();

            foreach (var c in text)
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);

            value = builder.ToString();

            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(text);

            value = Regex.Replace(
                Regex.Replace(Encoding.ASCII.GetString(bytes), @"\s{2,}|[^\w]", " ", RegexOptions.ECMAScript).Trim(),
                @"\s+", separator);

            return value.ToLowerInvariant();
        }

        public static string Truncar(this string texto, int tamanhoMaximo)
        {
            const string sufixo = "...";
            var stringTruncada = texto;

            if (tamanhoMaximo <= 0) return stringTruncada;
            var strLength = tamanhoMaximo - sufixo.Length;

            if (strLength <= 0) return stringTruncada;

            if (texto == null || texto.Length <= tamanhoMaximo) return stringTruncada;

            stringTruncada = texto.Substring(0, strLength);
            stringTruncada = stringTruncada.TrimEnd();
            stringTruncada += sufixo;
            return stringTruncada;
        }

        public static string DecodeHtmlChars(this string source)
        {
            var parts = source.Split(new[] { "&#x" }, StringSplitOptions.None);
            for (var i = 1; i < parts.Length; i++)
            {
                var n = parts[i].IndexOf(';');
                var number = parts[i].Substring(0, n);
                try
                {
                    var unicode = Convert.ToInt32(number, 16);
                    parts[i] = (char)unicode + parts[i].Substring(n + 1);
                }
                catch
                {
                }
            }

            return string.Join("", parts);
        }

        public static string RemoverAspasToUpper(this string str)
        {
            return RemoverAspasToUpper(str, null);
        }

        public static string RemoverAspasToUpper(this string str, string separador)
        {
            if (!string.IsNullOrEmpty(str.Trim()) && !string.IsNullOrWhiteSpace(str.Trim()))
                return str.Trim().Replace("'", "").ToUpper();
            return string.Empty;
        }

        public static string TrataString(this string str)
        {
            var myStr = string.Empty;
            myStr = string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str) ? string.Empty : str.Trim();
            if (myStr.Contains("\n"))
                myStr.Replace("\n", "").Trim();
            return myStr;
        }

        public static string ToCurrencyString(this decimal d)
        {
            var t = decimal.Truncate(d);
            if (d.Equals(t)) return d.ToString("0.##");

            return d.ToString("#,##0.00");
        }

        public static string DataFireBird(DateTime data)
        {
            data = Funcao.IsDateTime(data.ToString()) ? data : DateTime.Now;
            var ndata = string.Empty;
            var dia = data.Day >= 10 ? data.Day.ToString() : "0" + data.Day;
            var mes = data.Month >= 10 ? data.Month.ToString() : "0" + data.Month;

            ndata = string.Concat(mes, "/", dia, "/", data.Year);

            return ndata;
        }

        public static string ToPassword(this string str, string dtfun, string razsoc)
        {
            var pwd = string.Empty;
            var chave = string.Empty;
            var caracter = string.Empty;
            var ran = new Random();
            var expReg = @"(?=^.{8,10}$)(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?!.*\s).*$";

            str = string.IsNullOrEmpty(str) ? "V1aT0Lent!N0@" : str.TrataString();
            dtfun = string.IsNullOrEmpty(dtfun) ? DateTime.Now.ToShortDateString() : dtfun.TrataString();
            razsoc = string.IsNullOrEmpty(razsoc) ? "ViaTolentino" : razsoc.TrataString();
            chave = string
                .Concat(str, dtfun.Replace("/", ""), razsoc.Replace(".", "").Replace("&", "").Replace("¨", ""))
                .Replace(" ", "");
            chave = Regex.Replace(chave, expReg, "");

            //caracter = chave.Substring(ran.Next(1, chave.Length), 1);
            for (var i = 0; i < 7; i++)
                pwd += chave.Substring(ran.Next(1, chave.Length), 1).Trim();

            return pwd.Trim();
        }


        public static string RetirarAcentos(this string value)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            return Encoding.ASCII.GetString(bytes);
        }

        public static string RetirarCaracteres(this string value, params string[] characters)
        {
            if (string.IsNullOrWhiteSpace(value) || characters == null) return value;
            foreach (var character in characters) value = value.Replace(character, "");
            return value;
        }

        public static string RetirarAlfabeto(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            return Regex.Replace(value, "[^0-9]", "");
        }

        public static bool EmailValido(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            var rg = new Regex(@"^[A-Za-z0-9\._\-]+@[A-Za-z0-9\.\-]+\.([A-Za-z]{2,})$");

            return rg.IsMatch(value);
        }

        //Método que valida o Cep
        public static bool ValidaCep(this string cep)
        {
            if (cep.Length == 8) cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
            //txt.Text = cep;
            return Regex.IsMatch(cep, "[0-9]{5}-[0-9]{3}");
        }

        public static string PrimeiraMaiuscula(this string strString)
        {
            var strResult = "";

            if (strString.Length > 0)
            {
                strResult += strString.Substring(0, 1).ToUpper();
                strResult += strString.Substring(1, strString.Length - 1).ToLower();
            }

            return strResult;
        }

        public static string PrimeiraMaiusculaPalavras(this string strString)
        {
            var strResult = "";
            var booPrimeira = true;
            if (strString.Length > 0)
                for (var intCont = 0; intCont <= strString.Length - 1; intCont++)
                    if (booPrimeira && !strString.Substring(intCont, 1).Equals(" "))
                    {
                        strResult += strString.Substring(intCont, 1).ToUpper();
                        booPrimeira = false;
                    }
                    else
                    {
                        strResult += strString.Substring(intCont, 1).ToLower();
                        if (strString.Substring(intCont, 1).Equals(" ")) booPrimeira = true;
                    }

            return strResult;
        }

        public static string LetrasIniciaisDoNome(this string strString)
        {
            string[] reservadas = { "DO", "DOS", "DA", "DAS", "DE", "A" };
            var strResult = string.Empty;

            if (strString.Length > 0)
            {
                var PrimeiroNomeSacado = strString.ToUpper().Trim().Split(' ');

                for (var i = 0; i < PrimeiroNomeSacado.Length; i++)
                {
                    if (reservadas.Contains(PrimeiroNomeSacado[i]))
                        continue;
                    if (!string.IsNullOrEmpty(PrimeiroNomeSacado[i]))
                        strResult += "" + PrimeiroNomeSacado[i].Substring(0, 1);
                }
            }

            return strResult;
        }

        public static string PrimeiroNome(this string strString)
        {
            var strResult = string.Empty;

            if (strString.Length > 0)
            {
                var PrimeiroNomeSacado = strString.ToUpper().Split(' ');
                if (PrimeiroNomeSacado.Count() > 0)
                    strResult = "" + PrimeiroNomeSacado[0].Substring(0);
                else
                    strResult = strString;
            }

            return strResult;
        }


        //criado para esconder cookies
        public static string toEncod64(this string strString)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(strString));
        }

        //criado para ver cookies
        public static string toDencod64(this string strString)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(strString));
        }

        /// <summary>
        ///     Base 64 Encoding with URL and Filename Safe Alphabet using UTF-8 character set.
        /// </summary>
        /// <param name="str">The origianl string</param>
        /// <returns>The Base64 encoded string</returns>
        public static string Base64ForUrlEncode(this string strString)
        {
            var encbuff = Encoding.UTF8.GetBytes(strString);
            return HttpServerUtility.UrlTokenEncode(encbuff);
        }

        /// <summary>
        ///     Decode Base64 encoded string with URL and Filename Safe Alphabet using UTF-8.
        /// </summary>
        /// <param name="str">Base64 code</param>
        /// <returns>The decoded string.</returns>
        public static string Base64ForUrlDecode(this string strString)
        {
            var decbuff = HttpServerUtility.UrlTokenDecode(strString);
            return Encoding.UTF8.GetString(decbuff);
        }

        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            var result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }

        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            var result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable
            var result = param.Substring(startIndex, length);
            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex)
        {
            //start at the specified index and return all characters after it
            //and assign it to a variable
            var result = param.Substring(startIndex);
            //return the result of the operation
            return result;
        }


        public static string ToUpperNull(string valor)
        {
            if (valor != null)
                valor = valor.ToUpper();

            return valor;
        }

        public static string ToLowerNull(string valor)
        {
            if (valor != null)
                valor = valor.ToLower();

            return valor;
        }
    }
}