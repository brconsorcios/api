using System;

namespace exp.dados
{
    public class viewben
    {
        public virtual string id { get; set; }
        public virtual int produtos_id { get; set; }
        public virtual int empresas_id { get; set; }
        public virtual int adm_id { get; set; }
        public virtual string img { get; set; }
        public virtual bool disponivel { get; set; }
        public virtual int? id_identificador { get; set; }
        public virtual int? id_conve029tmp { get; set; }
        public virtual string cd_bem { get; set; }
        public virtual string nm_bem { get; set; }
        public virtual decimal? vl_bem { get; set; }
        public virtual int? id_bem { get; set; }
        public virtual short? pz_comercializacao { get; set; }
        public virtual short? no_pc_inicial { get; set; }
        public virtual short? no_pc_final { get; set; }
        public virtual decimal? vl_juridica { get; set; }
        public virtual decimal? vl_fisica { get; set; }
        public virtual int? id_taxa_plano { get; set; }
        public virtual int? id_plano_venda { get; set; }
        public virtual int? id_fabricante { get; set; }
        public virtual string cd_fabricante { get; set; }
        public virtual string nm_fabricante { get; set; }
        public virtual int? id_tipo_venda_grupo { get; set; }
        public virtual int? id_regiao_fiscal { get; set; }
        public virtual DateTime? dt_atualizacao { get; set; }
        public virtual int id_grupo { get; set; }
        public virtual string cd_grupo { get; set; }
        public virtual string nm_caracteristica { get; set; }


        /// <summary>
        ///     Para consultar indice de reajuste da parcela
        /// </summary>

        public decimal pe_ta { get; set; }

        public decimal pe_fr { get; set; }
        public decimal pe_sg { get; set; }
        public int indice_reajuste { get; set; }
        public int meses_restantes { get; set; }
        public virtual string st_situacao { get; set; }

        public virtual int? qt_participante { get; set; }
        public virtual decimal? pe_taxa_adm_plano { get; set; }
        public virtual decimal? pe_fundo_reserva_plano { get; set; }

        public virtual int? id_indexador { get; set; }


        public decimal ValorDaParcela()
        {
            decimal val = 0;

            if (vl_fisica != null)
                val = vl_fisica.Value;
            else
                try
                {
                    //definindo percentual de taxas de administração mais fundo de reserva
                    var percentual = (pe_ta + pe_fr) / 100;
                    //definindo percentual de seguro
                    var percentualsg = pe_sg / 100;
                    //Valor do seguro da parcela
                    var parcelasg = (decimal)(percentualsg * vl_bem);
                    //Parcela sem seguro
                    var parcelanova = (decimal)((vl_bem * percentual + vl_bem) / meses_restantes);

                    // Valor do seguro da parcela dos grupos que começam com E ou S
                    //if (!String.IsNullOrEmpty(cd_grupo))
                    //{
                    if (cd_grupo.ToUpper().StartsWith("E") || cd_grupo.ToUpper().StartsWith("S"))
                        parcelasg = (decimal)((vl_bem * percentual + vl_bem) * percentualsg);

                    //}
                    val = parcelanova + parcelasg;
                }
                catch (Exception e)
                {
                    //if (this.vl_fisica != null)
                    //{
                    //    val = this.vl_fisica.Value;
                    //}
                }

            return val;
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
            switch (indice_reajuste)
            {
                case 1:
                    return "CUB";
                case 2:
                    return "IGP-M";
                case 3:
                    return "INCC";
                case 4:
                    return "INPC";
                case 5:
                    return "SELIC";
                case 6:
                    if (id_indexador == 1 && produtos_id == 1) return "TABELA DE FÁBRICA";

                    return "IPCA";
                case 99:

                    if (produtos_id == 4) return "SEM CORREÇÃO";

                    return "TABELA DE FÁBRICA";

                default:
                    return "";
            }
        }
    }
}