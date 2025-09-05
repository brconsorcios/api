namespace exp.dados
{
    public class BemEscolhidoModel
    {
        public int? id_bem { get; set; }
        public virtual string BemEscolhido { get; set; }
        public decimal? Credito { get; set; }
        public virtual string Plano { get; set; }
        public virtual decimal? ParcelaInicial { get; set; }
        public virtual decimal? ParcelaMensal { get; set; }
    }
}