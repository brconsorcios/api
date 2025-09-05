using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Helpers
{
    public static class StringExtensions
    {
       

      

        public static string Truncar(this string texto, int tamanhoMaximo)
        {
            const string sufixo = "...";
            string stringTruncada = texto;

            if (tamanhoMaximo <= 0) return stringTruncada;
            int strLength = tamanhoMaximo - sufixo.Length;

            if (strLength <= 0) return stringTruncada;

            if (texto == null || texto.Length <= tamanhoMaximo) return stringTruncada;

            stringTruncada = texto.Substring(0, strLength);
            stringTruncada = stringTruncada.TrimEnd();
            stringTruncada += sufixo;
            return stringTruncada;
        }
        public static string DecodeHtmlChars(this string source)
        {
            string[] parts = source.Split(new string[] { "&#x" }, StringSplitOptions.None);
            for (int i = 1; i < parts.Length; i++)
            {
                int n = parts[i].IndexOf(';');
                string number = parts[i].Substring(0, n);
                try
                {
                    int unicode = Convert.ToInt32(number, 16);
                    parts[i] = ((char)unicode) + parts[i].Substring(n + 1);
                }
                catch { }
            }
            return String.Join("", parts);
        }

        public static String RemoverAspasToUpper(this string str)
        {
            return RemoverAspasToUpper(str, null);
        }

        public static String RemoverAspasToUpper(this string str, string separador)
        {
            if (!String.IsNullOrEmpty(str.Trim()) && !String.IsNullOrWhiteSpace(str.Trim()))
                return str.Trim().Replace("'", "").ToUpper();
            else
                return String.Empty;
        }

        public static String TrataString(this string str)
        {
            string myStr = String.Empty;
            myStr = (String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str)) ? String.Empty : str.Trim();
            if (myStr.Contains("\n"))
                myStr.Replace("\n", "").Trim();
            return myStr;
        }

        public static string ToCurrencyString(this decimal d)
        {
            decimal t = Decimal.Truncate(d);
            if (d.Equals(t))
            {
                return d.ToString("0.##");
            }
            else
            {
                return d.ToString("#,##0.00");
            }
        }

        public static String DataFireBird(DateTime data)
        {
            data = Funcao.IsDateTime(data.ToString()) ? data : DateTime.Now;
            string ndata = String.Empty;
            string dia = data.Day >= 10 ? data.Day.ToString() : "0" + data.Day;
            string mes = data.Month >= 10 ? data.Month.ToString() : "0" + data.Month;

            ndata = String.Concat(mes, "/", dia, "/", data.Year);

            return ndata;
        }

   

        public static string RetirarAcentos(this string value)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            return Encoding.ASCII.GetString(bytes);
        }

        public static string RetirarCaracteres(this string value, params string[] characters)
        {
            if (String.IsNullOrWhiteSpace(value) || characters == null)
            {
                return value;
            }
            foreach (var character in characters)
            {
                value = value.Replace(character, "");
            }
            return value;
        }

        public static string RetirarAlfabeto(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return value;
            }
            return Regex.Replace(value, "[^0-9]", "");
        }

        public static bool EmailValido(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            var rg = new Regex(@"^[A-Za-z0-9\._\-]+@[A-Za-z0-9\.\-]+\.([A-Za-z]{2,})$");

            return rg.IsMatch(value);
        }

        //Método que valida o Cep
        public static bool ValidaCep(this string cep)
        {
            if (cep.Length == 8)
            {
                cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
                //txt.Text = cep;
            }
            return System.Text.RegularExpressions.Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}"));
        }

        public static string PrimeiraMaiuscula(this string strString)
        {

            string strResult = "";

            if (strString.Length > 0)
            {
                strResult += strString.Substring(0, 1).ToUpper();
                strResult += strString.Substring(1, strString.Length - 1).ToLower();
            }

            return strResult;

        }

        public static string PrimeiraMaiusculaPalavras(this String strString)
        {
            string strResult = "";
            bool booPrimeira = true;
            if (strString.Length > 0)
            {
                for (int intCont = 0; intCont <= strString.Length - 1; intCont++)
                {
                    if ((booPrimeira) && (!strString.Substring(intCont, 1).Equals(" ")))
                    {
                        strResult += strString.Substring(intCont, 1).ToUpper();
                        booPrimeira = false;
                    }
                    else
                    {
                        strResult += strString.Substring(intCont, 1).ToLower();
                        if (strString.Substring(intCont, 1).Equals(" "))
                        {
                            booPrimeira = true;
                        }
                    }
                }
            }
            return strResult;
        }

        public static string LetrasIniciaisDoNome(this String strString)
        {

            string[] reservadas = { "DO", "DOS", "DA", "DAS", "DE", "A" };
            string strResult = string.Empty;

            if (strString.Length > 0)
            {
                string[] PrimeiroNomeSacado = strString.ToUpper().Trim().Split(' ');

                for (int i = 0; i < PrimeiroNomeSacado.Length; i++)
                {
                    if (reservadas.Contains(PrimeiroNomeSacado[i]))
                        continue;
                    if (!string.IsNullOrEmpty(PrimeiroNomeSacado[i]))
                        strResult += "" + PrimeiroNomeSacado[i].Substring(0, 1);
                }
            }
            return strResult;
        }
        public static string PrimeiroNome(this String strString)
        {
            string strResult = string.Empty;

            if (strString.Length > 0)
            {
                string[] PrimeiroNomeSacado = strString.ToUpper().Split(' ');
                if (PrimeiroNomeSacado.Count() > 0)
                {
                    strResult = "" + PrimeiroNomeSacado[0].Substring(0);
                }
                else
                {
                    strResult = strString;
                }
            }
            return strResult;
        }


      

        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }
        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable
            string result = param.Substring(startIndex, length);
            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex)
        {
            //start at the specified index and return all characters after it
            //and assign it to a variable
            string result = param.Substring(startIndex);
            //return the result of the operation
            return result;
        }


        //criado para esconder cookies
        public static string toEncod64(this string strString)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(strString));
        }
        //criado para ver cookies
        public static string toDencod64(this string strString)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(strString));
        }


    }
}
