using System;

namespace exp.dados
{
    public class loteria_federal_resultados
    {
        public int id { get; set; }
        public string cd_concurso { get; set; }
        public DateTime data_sorteio { get; set; }
        public string numero_premio_1 { get; set; }
        public string numero_premio_2 { get; set; }
        public string numero_premio_3 { get; set; }
        public string numero_premio_4 { get; set; }
        public string numero_premio_5 { get; set; }
        public decimal valor_premio_1 { get; set; }
        public decimal valor_premio_2 { get; set; }
        public decimal valor_premio_3 { get; set; }
        public decimal valor_premio_4 { get; set; }
        public decimal valor_premio_5 { get; set; }
        public string numero_sorte { get; set; }
    }
}