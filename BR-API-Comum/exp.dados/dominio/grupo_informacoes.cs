using System;

namespace exp.dados
{
    public class grupo_informacoes
    {
        public int id_grupo_informacoes { get; set; }
        public int id_grupo { get; set; }
        public string cd_grupo { get; set; }
        public int? qt_cota_vaga { get; set; }
        public DateTime? dt_assembleia { get; set; }
        public DateTime? dt_vencimento { get; set; }
        public string tp_tipo_sorteio { get; set; }
        public DateTime? dt_sorteio { get; set; }
    }
}