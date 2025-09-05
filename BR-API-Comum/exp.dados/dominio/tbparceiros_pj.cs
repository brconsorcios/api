using System;

namespace exp.dados
{
    public class tbparceiros_pj
    {
        public int id_tbparceiros { get; set; } //
        public string razaosocial { get; set; } //
        public DateTime? dt_abertura { get; set; } //
        public string insc_municipal { get; set; } //
        public string insc_estadual { get; set; } //

        #region Relacionamentos

        public tbparceiro tbparceiro { get; set; }

        #endregion
    }
}