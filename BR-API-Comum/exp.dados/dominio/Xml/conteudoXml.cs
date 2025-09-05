using System;
using System.Linq;

namespace exp.dados
{
    public class conteudoXml
    {
        //public string editoria { get; set; }
        public int id { get; set; }
        public int tipo_id { get; set; }
        public string titulo { get; set; }
        public string secao { get; set; }
        public string sinopse { get; set; }
        public string tags { get; set; }
        public string conteudotexto { get; set; }
        public DateTime? dtpublicacao { get; set; }
        public string path { get; set; }
        public bool manchete { get; set; }
        public bool capa { get; set; }
        public int? ordem { get; set; }
        public bool disponivel { get; set; }
        public int? usuario_criador { get; set; }
        public DateTime? dtcriado { get; set; }
        public int? usuario_modificou { get; set; }
        public DateTime? dtmodificado { get; set; }

        public static conteudoXml Convert(conteudo conteudo)
        {
            var conteudoXml = new conteudoXml();
            conteudoXml.id = conteudo.id;
            conteudoXml.tipo_id = conteudo.tipo_id;
            conteudoXml.titulo = conteudo.titulo;
            conteudoXml.secao = conteudo.secao;
            conteudoXml.sinopse = conteudo.sinopse;
            conteudoXml.tags = conteudo.tags;
            conteudoXml.conteudotexto = conteudo.conteudotexto;
            conteudoXml.dtpublicacao = conteudo.dtpublicacao;
            conteudoXml.path = conteudo.path;
            conteudoXml.manchete = conteudo.manchete;
            conteudoXml.capa = conteudo.capa;
            conteudoXml.ordem = conteudo.ordem;
            conteudoXml.disponivel = conteudo.disponivel;
            conteudoXml.usuario_criador = conteudo.usuario_criador;
            conteudoXml.dtcriado = conteudo.dtcriado;
            conteudoXml.usuario_modificou = conteudo.usuario_modificou;
            conteudoXml.dtmodificado = conteudo.dtmodificado;
            // conteudoXml.conteditorias = "";
            //conteudo.conteditorias;
            //conttopicos = new List<conttopico>();
            // conteudoXml.conteudosanexos = "";

            if (conteudo.conteudosanexos.Count() == 0)
            {
                //se for nulo nao conseguiu converter  
                conteudoXml.conteudosanexos = "";
            }
            else
            {
                var pathFolder = conteudo.conteudosanexos.FirstOrDefault().path;
                //string folder = Server.MapPath(anexo.path);
                var namefilep = conteudo.conteudosanexos.FirstOrDefault().filename;
                //string path = VirtualPathUtility.ToAbsolute("~/");
                var imag = pathFolder + namefilep;

                conteudoXml.conteudosanexos = imag;
            }

            conteudoXml.conteditorias = conteudo.conteditorias.editoria;


            //...
            return conteudoXml;
        }

        #region Relacionamentos

        //public virtual List<conttopico> conttopicos { get; set; }
        //public virtual conteditoriaXml conteditorias { get; set; }
        //public virtual List<conteudosanexoXml> conteudosanexos { get; set; }

        public string conteditorias { get; set; }
        public string conteudosanexos { get; set; }

        #endregion
    }
}