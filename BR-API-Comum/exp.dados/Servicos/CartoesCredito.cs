using exp.core;

namespace exp.dados
{
    public static class CartoesCredito
    {
        //public static indicaco PeparaIndicacao(indicaco indicacao, IndicacaoPgtoCartaoModel CartaoCredito)
        //{
        //    indicacao.id = CartaoCredito.id;
        //    if (!string.IsNullOrEmpty(CartaoCredito.cred))
        //    {
        //        indicacao.cred = CartaoCredito.cred.toEncod64();
        //    }
        //    indicacao.credcpf = CartaoCredito.credcpf;
        //    indicacao.credvenc = CartaoCredito.credvendtmes + "/" + CartaoCredito.credvendtano;
        //    if (!string.IsNullOrEmpty(CartaoCredito.credSegu))
        //    {
        //        indicacao.credSegu = CartaoCredito.credSegu.toEncod64();
        //    }
        //    indicacao.credtipo = CartaoCredito.credtipo;
        //    indicacao.nome_resp = CartaoCredito.nome_resp;
        //    indicacao.pgto_parceiro = true;
        //    if (CartaoCredito.check_pgto.Value)
        //    {
        //        indicacao.pgto_parceiro = false;
        //    }
        //    indicacao.id_forma_recebimento = "CC";

        //    return indicacao;
        //}


        //public static IndicacaoPgtoCartaoModel PeparaCC(IndicacaoPgtoCartaoModel CartaoCredito)
        //{
        //    IndicacaoPgtoCartaoModel CC = new IndicacaoPgtoCartaoModel();

        //    CC.id = CartaoCredito.id;
        //    if (!string.IsNullOrEmpty(CartaoCredito.cred))
        //    {
        //        CC.cred = CartaoCredito.cred.Trim().toEncod64();
        //    }
        //    CC.credcpf = CartaoCredito.credcpf;
        //    CC.credvendtmes = CartaoCredito.credvendtmes;
        //    CC.credvendtano = CartaoCredito.credvendtano;
        //    if (!string.IsNullOrEmpty(CartaoCredito.credSegu))
        //    {
        //        CC.credSegu = CartaoCredito.credSegu.Trim().toEncod64();
        //    }
        //    CC.credtipo = CartaoCredito.credtipo;
        //    CC.nome_resp = CartaoCredito.nome_resp;

        //    CC.check_pgto = CartaoCredito.check_pgto.Value;
        //    //CC.check_dadosbancarios = CartaoCredito.check_dadosbancarios.Value;
        //    CC.check_termo = CartaoCredito.check_termo.Value;

        //    return CC;
        //}

        public static IndicacaoPgtoCartaoModel PeparaCC(IndicacaoPgtoCartaoModel CartaoCredito)
        {
            if (!string.IsNullOrEmpty(CartaoCredito.cred))
            {
                var cred = CartaoCredito.cred;

                CartaoCredito.cred = cred.toEncod64();
            }

            if (!string.IsNullOrEmpty(CartaoCredito.credSegu))
            {
                var seg = CartaoCredito.credSegu;

                CartaoCredito.credSegu = seg.toEncod64();
            }

            return CartaoCredito;
        }
    }
}