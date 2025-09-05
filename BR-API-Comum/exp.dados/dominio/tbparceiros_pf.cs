using System;

namespace exp.dados
{
    public class tbparceiros_pf
    {
        public int id_tbparceiros { get; set; } //  int(11) NOT NULL DEFAULT '0',
        public string rg { get; set; } //  varchar(20) DEFAULT NULL COMMENT 'documento (registro nacional) s',
        public DateTime dt_expedicao { get; set; } //  datetime DEFAULT NULL,
        public string nm_orgao_emissor { get; set; } //  varchar(40) DEFAULT NULL COMMENT 'Emissor do documento ',
        public string nome_pai { get; set; } //  varchar(80) DEFAULT NULL COMMENT 'pai',
        public string nome_mae { get; set; } //  varchar(80) DEFAULT NULL COMMENT 'mae',
        public string sexo { get; set; } //  char(1) DEFAULT NULL COMMENT 'sexo (m – masculino, f – feminino) s',
        public string nm_nacionalidade { get; set; } //  varchar(60) DEFAULT NULL COMMENT 'nacionalidae',
        public string naturalidade { get; set; } //  varchar(60) DEFAULT NULL,
        public string profissao { get; set; } //  varchar(60) DEFAULT NULL,

        #region Relacionamentos

        public tbparceiro tbparceiro { get; set; }

        #endregion
    }
}