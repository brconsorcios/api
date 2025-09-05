using System;

namespace exp.dados
{
    public class viewbemantigo
    {
        public viewbemantigo()
        {
            meses_restantes = 0;
            id_grupo = 0;
            nm_fabricante = "";
            st_situacao = "";
            id_taxa_plano = 0;
            id_plano_venda = 0;
            id_fabricante = 0;
            cd_fabricante = "";
            id_tipo_venda_grupo = 0;
            id_regiao_fiscal = 0;
        }

        public virtual int id { get; set; }
        public virtual int produtos_id { get; set; }
        public virtual int empresas_id { get; set; }
        public virtual string img { get; set; }

        public virtual bool disponivel { get; set; }

        //public virtual Nullable<int> id_identificador { get; set; }
        //public virtual Nullable<int> id_conve029tmp { get; set; }
        public virtual string cd_bem { get; set; }
        public virtual string nm_bem { get; set; }

        public virtual int? id_bem { get; set; }

        public virtual decimal pz_comercializacao { get; set; }
        //public virtual Nullable<short> no_pc_inicial { get; set; }
        //public virtual Nullable<short> no_pc_final { get; set; }

        public virtual decimal? vl_bem { get; set; }
        public virtual decimal? vl_juridica { get; set; }
        public virtual decimal? vl_fisica { get; set; }


        public virtual DateTime? dt_atualizacao { get; set; }

        //public virtual string cd_grupo { get; set; }
        public virtual long RowNumber { get; set; }

        /// <summary>
        ///     Para consultar indice de reajuste da parcela
        /// </summary>

        public string pe_ta { get; set; }

        public string pe_fr { get; set; }

        public string pe_sg { get; set; }
        //public int indice_reajuste { get; set; }


        //DEFAULT para cadastro de indicações
        public virtual int id_grupo { get; set; }
        public int meses_restantes { get; set; }
        public virtual string nm_fabricante { get; set; }
        public virtual int? id_taxa_plano { get; set; }
        public virtual int? id_plano_venda { get; set; }
        public virtual int? id_fabricante { get; set; }
        public virtual string cd_fabricante { get; set; }
        public virtual int? id_tipo_venda_grupo { get; set; }
        public virtual int? id_regiao_fiscal { get; set; }
        public string st_situacao { get; set; }


        public decimal ValorDaParcela()
        {
            var valorparcela = vl_fisica.Value;

            return valorparcela;
        }

        public string SituacaoDoGrupo()
        {
            switch (st_situacao)
            {
                case "A":
                    return "GRUPO EM ANDAMENTO";
                case "F":
                    return "GRUPO EM FORMAÇÂO";
                default:
                    return "";
            }
        }


        public string IndiceReajuste()
        {
            if (produtos_id == 1)
                return
                    "Preços sujeitos à alteração conforme variação do INCC (variação anual); Seguro de vida incluso nas parcelas";

            return
                "Preços sujeitos à alteração conforme variação do IPCA (variação anual), ou pela variação do bem indexado; Seguro de vida incluso nas parcelas";
        }
    }
}