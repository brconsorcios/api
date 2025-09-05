namespace exp.dados
{
    public class EmissaoBoletoRetornoModel
    {
        public string NM_Local_Pagto { get; set; } //            string</NM_Local_Pagto>
        public string NM_Cedente { get; set; } //                string</NM_Cedente>
        public string DT_Documento { get; set; } //             string</DT_Documento>
        public string NO_Documento { get; set; } //              string</NO_Documento>
        public string Especie_Documento { get; set; } //         string</Especie_Documento>
        public string SN_Aceite { get; set; } //                 string</SN_Aceite>
        public string DT_Processamento { get; set; } //          string</DT_Processamento>
        public string NO_Carteira_Impressa_Boleto { get; set; } //string</NO_Carteira_Impressa_Boleto>
        public string Especie_Moeda { get; set; } //             string</Especie_Moeda>
        public string QT_Moeda { get; set; } //                 int</QT_Moeda>
        public string VL_Moeda { get; set; } //                  double</VL_Moeda>
        public string DT_Vencimento { get; set; } //             string</DT_Vencimento>
        public string Agencia_Cedente { get; set; } //           string</Agencia_Cedente>
        public string Nosso_Numero { get; set; } //              string</Nosso_Numero>
        public string VL_Documento { get; set; } //             double</VL_Documento>
        public string VL_Desconto { get; set; } //               double</VL_Desconto>
        public string VL_Outras_Deducoes { get; set; } //        double</VL_Outras_Deducoes>
        public string VL_Multa { get; set; } //                  double</VL_Multa>
        public string VL_Outros_Acrescimos { get; set; } //      double</VL_Outros_Acrescimos>
        public string VL_Cobrado { get; set; } //                double</VL_Cobrado>
        public string Sacado { get; set; } //                    string</Sacado>
        public string Linha_Digitavel { get; set; } //           string</Linha_Digitavel>
        public string CD_Barra { get; set; } //                 string</CD_Barra>
        public string CD_Banco { get; set; } //                 string</CD_Banco>
        public string Mensagem_Compensacao { get; set; } //     string</Mensagem_Compensacao>
        public string Mensagem_Recibo { get; set; } //           string</Mensagem_Recibo>
        public string NM_Banco_Reduzido { get; set; } //        string</NM_Banco_Reduzido>
        public string Uso_Banco { get; set; } //                string</Uso_Banco>
        public string CD_Baixa { get; set; } //                 string</CD_Baixa>
        public string Endereco_Completo { get; set; } //         string</Endereco_Completo>
        public string CD_Inscricao_Nacional { get; set; } //    string</CD_Inscricao_Nacional>
        public string Return_Code { get; set; } //               int</Return_Code>
        public string ErrMsg { get; set; } //                    string</ErrMsg>


        public string NM_Sacado { get; set; } // 
        public string NO_Identificador { get; set; } // 
        public string CEP_ECTPOSTNET { get; set; } // 
        public string CIF { get; set; } // 
    }
}