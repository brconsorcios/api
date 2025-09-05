using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Helpers
{
    public class Message
    {
        public static string RequiredField = "Campo obrigatório";

        /// <summary>
        /// Mensagem para estouro de campos
        /// </summary>
        public static string MaxLength = "Limite de tamanho do campo estourado";

        /// <summary>
        /// Mensagem de nenhum registro encontrado
        /// </summary>
        public static string NoDataFound = "Não existem informações para a consulta realizada.";

        /// <summary>
        /// Mensagem de nenhum registro salvo
        /// </summary>
        public static string NoDataSaved = "Nenhum registro salvo";

        /// <summary>
        /// Mensagem de dados salvos com sucesso
        /// </summary>
        public static string DataSavedSuccess = "Dados salvos com sucesso";

        /// <summary>
        /// Mensagem de dados deletados com sucesso
        /// </summary>
        public static string DataDeletedSuccess = "Registro deletado com sucesso";

        /// <summary>
        /// Mensagem de cpf inválido
        /// </summary>
        public static string InvalidCpf = "CPF informado inválido";

        /// <summary>
        /// Mensagem de cnpj inválido
        /// </summary>
        public static string InvalidCnpj = "CNPJ informado inválido";

        /// <summary>
        /// Mensagem para e-mail inválido
        /// </summary>
        public static string InvalidEmail = "E-mail informado inválido";

        /// <summary>
        /// Mensagem ao alterar senha
        /// </summary>
        public static string PasswordModifyedSuccess = "Troca de senha realizada";

        /// <summary>
        /// Mensagem para login não afetuado
        /// </summary>
        public static string UserNotFound = "Usuário ou senha inválidos";

        /// <summary>
        /// Mensagem para filtros de data onde a data inicial seja maior que a data final
        /// </summary>
        public static string InitialDateGreaterThanFinalDate = "A data inicial não pode ser maior que a data final";

        /// <summary>
        /// Mensagem de erro padrão concatenada a mensagem da exception
        /// </summary>
        /// <param name="exceptionMessage">Mensagem da exception</param>
        /// <returns></returns>
        public static string GetError(string exceptionMessage)
        {
            return string.Format("Ocorreu um erro inesperado ao realizar a operação. Erro: {0}", exceptionMessage);
        }

        public static string DataPublishedSuccess = "Dados publicados com sucesso";
    }
}
