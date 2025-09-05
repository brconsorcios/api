using System;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

namespace exp.core
{
    public static class Funcao
    {
        /// <summary>
        ///     Método que verifica as string e retorna a string tratada,
        ///     caso ela esteja vazia ou nula ela receberá o parametro de retorno
        ///     que foi passado na chamada do método.
        /// </summary>
        /// <param name="_str">Texto a ser tratado</param>
        /// <param name="retorno">Tipo de retorno desejado para o tratamento do texto caso seja vazio ou nulo</param>
        /// <returns></returns>
        public static string IsEmpty(this string _str, string retorno = null)
        {
            _str += string.Concat(_str, "");
            _str += _str.Trim();

            if (string.IsNullOrEmpty(_str) || string.IsNullOrWhiteSpace(_str))
                return retorno;
            return _str;
        }

        public static bool IsDate(string txtDate)
        {
            DateTime tempDate;
            var enUS = new CultureInfo("en-US");

            return DateTime.TryParseExact(txtDate, "MM/dd/yyyy", enUS, DateTimeStyles.None, out tempDate)
                ? true
                : false;
        }

        public static bool IsDateTime(string txtDate)
        {
            DateTime tempDate;

            return DateTime.TryParse(txtDate, out tempDate) ? true : false;
        }

        public static bool IsNumeric(string stringToTest)
        {
            int result;
            return int.TryParse(stringToTest, out result);
        }

        public static bool IsDecimal(string stringToTest)
        {
            decimal result;
            return decimal.TryParse(stringToTest, out result);
        }


        public static bool EmailValido(string email)
        {
            var rg = new Regex(
                @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

            if (rg.IsMatch(email))
                return true;
            return false;
        }

        public static bool SenhaValida(string senha)
        {
            //Regex rg = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            var rg = new Regex(@"(?=^.{8,15}$)(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?!.*\s).*$");

            if (rg.IsMatch(senha))
                return false;
            return true;
        }

        //Método que valida o Cep
        public static bool ValidaCep(string cep)
        {
            if (cep.Length == 8) cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
            //txt.Text = cep;
            return Regex.IsMatch(cep, "[0-9]{5}-[0-9]{3}");
        }

        public static bool IsUrl(string http)
        {
            var rgx = new Regex(@"^((http)|(https)|(ftp))://([- w]+.)+w{2,3}(/ [%-w]+(.w{2,})?)*$");
            if (rgx.IsMatch(http)) return true;

            return false;
        }

        public static bool IsTelefone(string telefone)
        {
            var rgx = new Regex(@"^([0-9]{2})s[0-9]{4}-[0-9]{4}$");
            if (rgx.IsMatch(telefone)) return true;

            return false;
        }

        public static bool IsCEP(string cep)
        {
            cep = cep.RetirarAlfabeto();
            cep = cep.Replace(".", "");
            cep = cep.Replace("-", "");
            cep = cep.Replace(" ", "");
            var Rgx = new Regex(@"^\d{8}$");
            if (!Rgx.IsMatch(cep))
                return false;
            return true;
        }

        //NomeValido 

        public static bool NomeValido(string nome)
        {
            var rgx = new Regex(@"^[aA-zZ]+((s[aA-zZ]+)+)?$");
            if (rgx.IsMatch(nome))
                return true;
            return false;
        }


        public static bool IsCnpj(string cnpj)
        {
            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (var i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (var i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto;
            return cnpj.EndsWith(digito);
        }


        public static bool IsCpf(string cpf)
        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto;
            return cpf.EndsWith(digito);
        }

        /// <summary>
        ///     Função que verifica se a string informada “Tes123@#$” will be accepted.
        ///     UMA LETRA MINUSCULA
        ///     UMA LETRA MAIUSCULA
        ///     UM NUMERO
        ///     UM ESPECIAL
        ///     NO MINIMO 8 CARACTERES
        /// </summary>
        /// <param name=” password”></param>
        /// <returns></returns>
        public static bool IsPasswordStrong(string password)
        {
            var tamanhoMinimo = 8;
            var tamanhoMinusculo = 1;
            var tamanhoMaiusculo = 1;
            var tamanhoNumeros = 1;
            var tamanhoCaracteresEspeciais = 1;

            // Definição de letras minusculas
            var regTamanhoMinusculo = new Regex("[a-z]");

            // Definição de letras minusculas
            var regTamanhoMaiusculo = new Regex("[A-Z]");

            // Definição de letras minusculas
            var regTamanhoNumeros = new Regex("[0-9]");

            // Definição de letras minusculas
            var regCaracteresEspeciais = new Regex("[^a-zA-Z0-9]");

            // Verificando tamanho minimo
            if (password.Length < tamanhoMinimo) return false;

            // Verificando caracteres minusculos
            if (regTamanhoMinusculo.Matches(password).Count < tamanhoMinusculo) return false;

            // Verificando caracteres maiusculos
            if (regTamanhoMaiusculo.Matches(password).Count < tamanhoMaiusculo) return false;

            // Verificando numeros
            if (regTamanhoNumeros.Matches(password).Count < tamanhoNumeros) return false;

            // Verificando os diferentes
            if (regCaracteresEspeciais.Matches(password).Count < tamanhoCaracteresEspeciais) return false;

            return true;
        }

        public static bool ValidaNumero(string numero)
        {
            var rx = new Regex(@"^\d+$");
            return rx.IsMatch(numero);
        }

        public static string SomenteNumeros(string toNormalize)
        {
            var resultString = string.Empty;
            var regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(toNormalize, "");
            return resultString;
        }


        public static string HexConverter(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static string RGBConverter(Color c)
        {
            return "RGB(" + c.R + "," + c.G + "," + c.B + ")";
        }

        public static bool ValorRendaCompativel(decimal vlr_parcela, decimal vlr_renda)
        {
            if (vlr_parcela * 3 > vlr_renda)
                return false;
            return true;
        }
    }
}