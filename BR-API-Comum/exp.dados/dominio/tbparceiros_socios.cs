using System;
using System.ComponentModel.DataAnnotations;

namespace exp.dados
{
    public class tbparceiros_socios
    {
        [Key] public int id { get; set; } //

        public int id_tbparceiros { get; set; } //
        public string nm_socio { get; set; } //
        public string cpf_socio { get; set; } //
        public string sexo_socio { get; set; } //
        public DateTime? dt_nasc_socio { get; set; } //
        public string rg { get; set; } //
        public DateTime? dt_expedicao { get; set; } //` datetime NOT NULL,
        public string uf { get; set; } //
        public string nm_orgao_emissor { get; set; } //
        public string nome_pai { get; set; } //
        public string nome_mae { get; set; } //
        public string representantelegal { get; set; } //
        public string assinaturaconjunta { get; set; } //
        public string telefone { get; set; } //

        #region Relacionamentos

        public tbparceiro tbparceiro { get; set; }

        #endregion
    }
}