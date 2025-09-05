using System;
using System.Collections.Generic;

namespace exp.dados
{
    public class autorizacao_cobranca_digital
    {
        public autorizacao_cobranca_digital()
        {
            autorizacao_cobranca_digital_cota = new List<autorizacao_cobranca_digital_cota>();
        }

        public int id_autorizacao_cobranca_digital { get; set; }
        public string cpf_cnpj { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime data_adesao { get; set; }

        #region RELACIONAMENTOS

        public List<autorizacao_cobranca_digital_cota> autorizacao_cobranca_digital_cota { get; set; }

        #endregion
    }
}