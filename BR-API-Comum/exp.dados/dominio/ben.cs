using System;

namespace exp.dados
{
    public class ben
    {
        #region Properties

        public virtual string id { get; set; }
        public virtual int produtos_id { get; set; }
        public virtual int empresas_id { get; set; }
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
        public virtual int? id_grupo { get; set; }
        public virtual string cd_grupo { get; set; }
        public virtual string st_situacao { get; set; }
        public virtual int? pz_restante { get; set; }
        public virtual decimal? pe_taxa_adm_plano { get; set; }
        public virtual decimal? pe_fundo_reserva_plano { get; set; }
        public virtual decimal? pe_adesao_plano { get; set; }
        public virtual string sn_permite_reserva { get; set; }
        public virtual int? id_assembleia { get; set; }
        public virtual int? qt_participante { get; set; }
        public virtual string st_negociacao { get; set; }
        public virtual int? id_indexador { get; set; }
        public virtual decimal? pe_sg_f { get; set; }
        public virtual decimal? pe_sg_j { get; set; }
        public virtual decimal? vl_sg_f { get; set; }
        public virtual decimal? vl_sg_j { get; set; }

        #endregion

        #region Relacionamentos

        public produto produto { get; set; }
        public empresa empresa { get; set; }

        #endregion
    }
}