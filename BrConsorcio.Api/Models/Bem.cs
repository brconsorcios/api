using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class Bem
    {
        public  string id { get; set; }
        public  int produtos_id { get; set; }
        public  int empresas_id { get; set; }
        public  int adm_id { get; set; }
        public  string img { get; set; }
        public  bool disponivel { get; set; }
        public int? id_identificador { get; set; }
        public int? id_conve029tmp { get; set; }
        public  string cd_bem { get; set; }
        public  string nm_bem { get; set; }
        public decimal? vl_bem { get; set; }
        public int? id_bem { get; set; }
        public short? pz_comercializacao { get; set; }
        public short? no_pc_inicial { get; set; }
        public short? no_pc_final { get; set; }
        public decimal? vl_juridica { get; set; }
        public decimal? vl_fisica { get; set; }
        public int? id_taxa_plano { get; set; }
        public int? id_plano_venda { get; set; }
        public int? id_fabricante { get; set; }
        public  string cd_fabricante { get; set; }
        public  string nm_fabricante { get; set; }
        public int? id_tipo_venda_grupo { get; set; }
        public int? id_regiao_fiscal { get; set; }
        public DateTime? dt_atualizacao { get; set; }
        public  int id_grupo { get; set; }
        public  string cd_grupo { get; set; }
        public  string nm_caracteristica { get; set; }

        public BemTaxas Taxas { get; set; }

        /// <summary>
        /// Para consultar indice de reajuste da parcela
        /// </summary>

        public decimal pe_ta { get; set; }
        public decimal pe_fr { get; set; }
        public decimal pe_sg { get; set; }
        public int indice_reajuste { get; set; }
        public int meses_restantes { get; set; }
        public  string st_situacao { get; set; }


        public decimal ValorDaParcela()
        {
            decimal val = 0;

            try
            {
                //definindo percentual de taxas de administração mais fundo de reserva
                decimal percentual = (decimal)((pe_ta + pe_fr) / 100);
                //definindo percentual de seguro
                decimal percentualsg = (decimal)(pe_sg / 100);
                //Valor do seguro da parcela
                decimal parcelasg = (decimal)(percentualsg * vl_bem);
                //Parcela sem seguro
                decimal parcelanova = (decimal)(((vl_bem * percentual) + vl_bem) / meses_restantes);

                // Valor do seguro da parcela dos grupos que começam com E ou S
                //if (!String.IsNullOrEmpty(cd_grupo))
                //{
                if (cd_grupo.ToUpper().StartsWith("E") || cd_grupo.ToUpper().StartsWith("S"))
                    parcelasg = (decimal)(((vl_bem * percentual) + vl_bem) * percentualsg);
                //}

                val = parcelanova + parcelasg;

            }
            catch (Exception e)
            {
                if (this.vl_fisica != null)
                {
                    val = this.vl_fisica.Value;
                }
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
                    return "IPCA";
                case 99:

                    if (produtos_id == 4)
                    {
                        return "SEM CORREÇÃO";
                    }
                    else
                    {
                        return "TABELA DE FÁBRICA";
                    }

                default:
                    return "";
            }
        }

    }
}
