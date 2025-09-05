namespace exp.dados
{
    public class CampainhaSuperpayModel
    {
        public int numeroTransacao { get; set; }

        //Código que identifica a transação dentro do SuperPay Numérico 
        public long codigoEstabelecimento { get; set; }

        //Código que identifica o estabelecimento dentro do SuperPay (fornecido pelo gateway) Numérico
        public string campoLivre1 { get; set; }

        //Campo Livre 1 Alfa Numérico
        public string campoLivre2 { get; set; }

        //Campo Livre 2 Alfa Numérico
        public string campoLivre3 { get; set; }

        //Campo Livre 3 Alfa Numérico
        public string campoLivre4 { get; set; }

        //Campo Livre 4 Alfa Numérico
        public string campoLivre5 { get; set; }
        //Campo Livre 5 Alfa Numérico
    }
}