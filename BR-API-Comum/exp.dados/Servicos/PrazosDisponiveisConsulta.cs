namespace exp.dados
{
    public class PrazosDisponiveisConsulta
    {
        //public List<PrazosDisponiveisDetalhe> ListaDetalhe { get; set; }

        public PrazosDisponiveisConsulta()
        {
            //ListaDetalhe = new List<PrazosDisponiveisDetalhe>();
            Return_Code = "0";
        }

        public string CD_Bem { get; set; }
        public string NM_Bem { get; set; }
        public string VL_Bem { get; set; }
        public string ID_Bem { get; set; }
        public string ID_Grupo { get; set; }
        public string CD_Grupo { get; set; }
        public string ST_Situacao { get; set; }
        public string PZ_Plano { get; set; }
        public string PZ_Restante { get; set; }
        public string PE_Taxa_Adm_Plano { get; set; }
        public string PE_Fundo_Reserva_Plano { get; set; }
        public string PE_Adesao_Plano { get; set; }
        public string SN_Permite_Reserva { get; set; }
        public string VL_Juridica { get; set; }
        public string VL_Fisica { get; set; }
        public string ID_Taxa_Plano { get; set; }
        public string ID_Plano_Venda { get; set; }
        public string ID_Tipo_Venda_Grupo { get; set; }
        public string ID_Assembleia { get; set; }
        public string QT_Participante { get; set; }
        public string Return_Code { get; set; }
        public string ErrMsg { get; set; }
        public string ST_Negociacao { get; set; }
        public string PE_SG_F { get; set; }
        public string PE_SG_J { get; set; }
        public string VL_SG_F { get; set; }
        public string VL_SG_J { get; set; }
    }
}