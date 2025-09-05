using System.Collections.Generic;

namespace exp.dados
{
    public class site
    {
        public site()
        {
            indicacoes = new List<indicaco>();
            filiais = new List<filiai>();
            homecolunas = new List<homecoluna>();
            pesquisa_resultados = new List<pesquisa_resultados>();
            propostaparcerias = new List<propostaparceria>();
            bensgrupovendas = new List<bensgrupovenda>();
            bensdiversos = new List<bensdiverso>();
            conteudos = new List<conteudo>();
            vagas = new List<vaga>();
        }

        public int id_site { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string pws { get; set; }
        public int id_empresa { get; set; }
        public int id_ponto_venda { get; set; }
        public int id_comissionado { get; set; }
        public string cd_unidade_negocio_parceiro { get; set; }
        public bool ativo { get; set; }
        public int id_ponto_venda_desencana { get; set; }
        public int id_comissionado_desencana { get; set; }


        public List<indicaco> indicacoes { get; set; }
        public List<filiai> filiais { get; set; }
        public empresa empresa { get; set; }
        public List<homecoluna> homecolunas { get; set; }
        public List<propostaparceria> propostaparcerias { get; set; }
        public List<bensgrupovenda> bensgrupovendas { get; set; }
        public List<bensdiverso> bensdiversos { get; set; }
        public List<conteudo> conteudos { get; set; }

        public List<ouvidoria> ouvidorias { get; set; }

        public List<pesquisa_resultados> pesquisa_resultados { get; set; }

        public List<vaga> vagas { get; set; }

        public List<vinculovaga> vinculovagas { get; set; }
    }
}