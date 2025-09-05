namespace exp.dados
{
    public class viewbemsite
    {
        public virtual int id_site { get; set; }

        public virtual string chave_bem { get; set; }

        public virtual decimal valor_bem { get; set; }

        public virtual decimal valor_parcela { get; set; }

        public virtual int id_produto { get; set; }

        public virtual string nome_bem { get; set; }
    }
}