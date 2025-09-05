using BrConsorcio.Api.Models;

namespace BrConsorcio.Api.Helpers
{
    public static class PagamentoHelper
    {
        public static void PeparaCC(ref IndicacaoPgtoCartaoModel CartaoCredito)
        {
            if (!string.IsNullOrEmpty(CartaoCredito.cred))
            {
                string cred = CartaoCredito.cred;

                CartaoCredito.cred = cred.toEncod64();
            }

            if (!string.IsNullOrEmpty(CartaoCredito.credSegu))
            {
                string seg = CartaoCredito.credSegu;

                CartaoCredito.credSegu = seg.toEncod64();
            }
            //    return CartaoCredito;
        }

        public static bool VerificaRetornoStatusSuperPay(int statuspgto)
        {
            bool voltar = false;
            switch (statuspgto)
            {
                /// Contao via telefone 10/02/2015 feito pelo Gustavo
                /// Segunto a SuperPay o WebServices não retornará nenhum Status do tipo transitórios,
                /// ou seja, os status 2,5,6,8,15,18,30 não serão retornados.
                //

                case 1:  //Autorizado e Confirmado A transação está paga. Final
                    voltar = false;
                    break;
                //case 2:  //Autorizado A transação ainda será capturada na operadora. Transitório
                //    voltar = true; // precisamos analisar
                //    break;
                case 3:  //Não Autorizado A transação foi negada pela operadora.Final
                    voltar = true;
                    break;
                //case 5:  //Transação em Andamento A transação está em andamento. Transitório
                //    voltar = false; // precisamos analisar
                //    break;
                //case 6:  //Boleto em Compensação A transação ainda não está paga, boleto está em processo de compensação / baixa. Transitório
                //    voltar = true; // precisamos analisar
                //    break;
                //case 8:  //Aguardando Pagamento A transação está no SuperPay, aguardando o pagamento ou pedidos em processo de retentativa. Transitório
                //    voltar = false; // precisamos analisar
                //    break;
                case 9:  //Falha na Operadora A transação não foi autorizada pela operadora. Houve um problema em seu processamento Final
                    voltar = true; // precisamos analisar
                    break;

                /// (13 e 14) Status quando é solicitado o cancelamento
                ///quando o adiquirente(BR Consorcios) solicitar o cancelamento
                ///
                case 13: //Cancelado A transação foi cancelada na adquirente Final
                    voltar = true; // precisamos analisar
                    break;
                case 14: //Estornada A venda foi cancelada totalmente na adquirente Final
                    voltar = true; // precisamos analisar
                    break;


                //case 15: //Em Análise de Risco A transação foi enviada para o sistema de análise de riscos / fraudes. Resposta ainda não foi enviada pelo analisador Transitório
                //    voltar = true; // precisamos analisar
                //    break;
                case 17: //Recusado Análise de Risco A transação foi negada pelo sistema análise de Risco / Fraude Final
                    voltar = true; // precisamos analisar
                    break;
                //case 18: //Falha no envio para Análise de Risco Falha. Não foi possível enviar pedido para a análise de Risco / Fraude, porém será reenviada. Transitório
                //    voltar = true; // precisamos analisar
                //    break;

                ///Não estamos utilizando o sistema de boleto
                //case 21: //Boleto Pago a menor O boleto está pago com valor divergente do emitido Final
                //    voltar = true; // precisamos analisar
                //    break;
                //case 22: //Boleto Pago a maior O boleto está pago com valor divergente do emitido Final
                //    voltar = true; // precisamos analisar
                //    break;
                case 23: //Estorno Parcial A venda foi cancelada na adquirente parcialmente Final
                    voltar = true; // precisamos analisar
                    break;
                //case 30: //Operação em andamento Transação em curso de pagamento Transitório
                //    voltar = false; // precisamos analisar
                //    break;
                case 31: //Transação já efetuada Transação já efetuada e efetivada com status final Final
                    voltar = true; // precisamos analisar
                    break;
            }
            return voltar;
        }
    }
}
