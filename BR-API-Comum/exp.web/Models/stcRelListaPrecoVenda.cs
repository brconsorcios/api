using System;

namespace exp.web.Models
{
    public class stcRelListaPrecoVenda
    {
        public virtual int produtos_id { get; set; }
        public virtual int empresas_id { get; set; }
        public virtual string img { get; set; }
        public virtual bool? ativo { get; set; }

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
        public virtual DateTime? dt_atualizacao { get; set; }
    }
}