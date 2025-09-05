namespace exp.dados
{
    public class autorizacao_cobranca_digital_cota
    {
        public virtual int id_autorizacao_cobranca_digital_cota { get; set; }
        public virtual int id_autorizacao_cobranca_digital { get; set; }
        public virtual int id_cota { get; set; }
        public virtual string cd_cota { get; set; }
        public virtual string cd_grupo { get; set; }
        public virtual int versao { get; set; }

        #region RELACIONAMENTOS

        public autorizacao_cobranca_digital autorizacao_cobranca_digital { get; set; }

        #endregion
    }
}