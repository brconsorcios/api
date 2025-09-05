using System.ComponentModel.DataAnnotations;

namespace exp.dados
{
    public class IndicacaoBemEscolhidoModel
    {
        public int? codigo_vendedor { get; set; }
        public int? status { get; set; }
        public int? codigo_parceiro { get; set; }
        public int? codigo_campanha { get; set; }

        /// <summary>
        ///     Campos para descricao do bem escolhido
        /// </summary>

        #region BEM ESCOLHIDO

        // public virtual int id_bem { get; set; }
        [Required(ErrorMessage = "O Bem não foi identificado")]
        public string chave { get; set; }

        //public virtual string nm_bem { get; set; }//ok BemEscolhido
        //public virtual string pz_comercializacao { get; set; }//ok plano
        //public virtual Nullable<decimal> vl_bem { get; set; }//ok credito
        //public virtual Nullable<decimal> vl_parcela { get; set; }//ok parcelamensal

        //public Nullable<decimal> vl_ta_inscricao { get; set; }
        //public string faixa_valores { get; set; }
        //public string faixa_pe_fc { get; set; }
        //public string faixa_ta { get; set; }

        //public Nullable<decimal> pe_fc { get; set; }
        //public Nullable<decimal> pe_ta_inscricao { get; set; }

        //public Nullable<decimal> pe_ta_plano { get; set; }
        //public Nullable<decimal> pe_fr_plano { get; set; }
        //public Nullable<decimal> pe_sg { get; set; }
        //public Nullable<decimal> pe_ta { get; set; }


        //public string cd_plano_venda { get; set; }
        //public string nm_plano_venda { get; set; }
        //public int no_parcela_inicial { get; set; }
        //public int no_parcela_final { get; set; }
        //public int qt_participante { get; set; }
        //public string nm_fabricante { get; set; }

        #endregion
    }
}