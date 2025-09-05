using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class Plano
    {
        public short? no_pc_final { get; set; }
        public int? id_taxa_plano { get; set; }
        public int? id_plano_venda { get; set; }
        public int? id_fabricante { get; set; }
        public string cd_fabricante { get; set; }
        public string nm_fabricante { get; set; }
        public int? id_tipo_venda_grupo { get; set; }
        public int? id_regiao_fiscal { get; set; }
        public DateTime? dt_atualizacao { get; set; }
        public int id_grupo { get; set; }
        public string cd_grupo { get; set; }
        public string nm_caracteristica { get; set; }
        public decimal pe_ta { get; set; }
        public decimal pe_fr { get; set; }
        public decimal pe_sg { get; set; }
        public int indice_reajuste { get; set; }
        public decimal? vl_fisica { get; set; }
        public decimal? vl_juridica { get; set; }
        public string st_situacao { get; set; }
        public short? no_pc_inicial { get; set; }
        public string id { get; set; }
        public int produtos_id { get; set; }
        public int empresas_id { get; set; }
        public int adm_id { get; set; }
        public string img { get; set; }
        public int meses_restantes { get; set; }
        public bool disponivel { get; set; }
        public int? id_conve029tmp { get; set; }
        public string cd_bem { get; set; }
        public string nm_bem { get; set; }
        public decimal? vl_bem { get; set; }
        public int? id_bem { get; set; }
        public short? pz_comercializacao { get; set; }
        public int? id_identificador { get; set; }
    }
}
