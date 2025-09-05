namespace exp.dados
{
    public class PrazosDisponiveisDetalhe
    {
        public PrazosDisponiveisDetalhe()
        {
            Return_Code = "0";
        }

        public string Return_Code { get; set; }
        public string ErrMsg { get; set; }
        public string NM_Bem { get; set; }
        public string VL_Bem { get; set; }
        public string ID_Grupo { get; set; }
        public string CD_Grupo { get; set; }
        public string ST_Situacao { get; set; }
        public string SN_Permite_Reserva { get; set; }
        public string NO_PC_Inicial { get; set; }
        public string NO_PC_Final { get; set; }
        public string VL_Juridica { get; set; }
        public string VL_Fisica { get; set; }
    }
}