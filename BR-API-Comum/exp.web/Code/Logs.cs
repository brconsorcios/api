using System;
using System.IO;
using System.Web;

namespace exp.web.Code
{
    public class Logs
    {
        /// <summary>
        ///     Salva o LOG de erros, cria um novo arquivo para cada dia.
        /// </summary>
        /// <param name="msg"></param>
        public static void Save(string strFilename, string msg)
        {
            //Path do arquivo txt
            //C:\inetpub\wwwroot\nomedosite\App_Data\log-20111024.txt
            var strFile = HttpContext.Current.Server.MapPath("~/" + strFilename);


            //Se arquivo não existir
            if (!File.Exists(strFile))
                //Criar o arquivo, 
                //Estou usando o using para fazer o Dispose automático do arquivo após criá-lo.
                using (var fs = File.Create(strFile))
                {
                }

            //Escreve o Erro no txt
            //Os erros são concatenados, ou seja, não são sobreescritos.
            using (var w = File.AppendText(strFile))
            {
                var _msg = string.Empty;
                var URL = HttpContext.Current.Request.Url.AbsoluteUri;

                //Adicionar um separador
                _msg = "#############################################################\r\n";
                //Data do erro
                _msg += "Data:" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "\r\n";
                //URL do erro
                _msg += "URL:" + URL + "\r\n";
                //Adicionando a mensagem
                _msg += msg;
                //quebra de lina e nova linha
                _msg += "\r\n\r\n";

                //Escreve no arquivo
                w.Write(_msg);
                //Fecha
                w.Close();
            }
        }
    }
}