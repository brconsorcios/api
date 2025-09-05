namespace exp.dados.Servicos
{
    public class PagConsorcioEnviarTransacao
    {
        public string ContratoNumero { get; set; } // string
        public string ContratoGrupo { get; set; } // string
        public string ContratoCota { get; set; } //string
        public decimal ContratoCredito { get; set; } // decimal  Valor do Bem
        public decimal ContratoValor { get; set; } // decimal Valor da Parcela a Pagar
        public string ContratoDescricao { get; set; } // string

        public string Nome { get; set; } // string
        public string Email { get; set; } // string
        public string CpfCnpj { get; set; } // string
        public string TipoPessoa { get; set; }

        public string Telefone { get; set; } // string
        public string Cep { get; set; } // string
        public string Celular { get; set; } // string
        public string Logradouro { get; set; } // string
        public string Bairro { get; set; } // string
        public string Complemento { get; set; } // string
        public string Cidade { get; set; } // string
        public string Estado { get; set; } // string

        public string VendedorCodigo { get; set; } // string
        public string VendedorNome { get; set; } // string
        public string VendedorEmail { get; set; } // string
        public string VendedorCelular { get; set; } // string

        public string CartaoTitular { get; set; } // string
        public string CartaoTitularCPF { get; set; } // string
        public string CartaoNumero { get; set; } // string
        public int CartaoID { get; set; } // int
        public int CartaoValidadeAno { get; set; } // int
        public int CartaoValidadeMes { get; set; } // int
        public string CartaoLogradouro { get; set; } // string
        public string CartaoLogradouroNumero { get; set; } // string
        public string CartaoCidade { get; set; } // string
        public string CartaoEstado { get; set; } // string
        public string CartaoCep { get; set; } // string
        public int CartaoParcelas { get; set; } // int

        public int TransacaoID { get; set; } // int
    }

    public class PagConsorcioRetornoTransacao
    {
        public string TransacaoID { get; set; } //": 102,
        public string Codigo { get; set; } //": "00",
        public string Descricao { get; set; } //": "Transação Autorizada",
        public string Autorizacao { get; set; } //": "123456",
        public string Status { get; set; } //": "Transação Autorizada"
        public int TransacaoStatusId { get; set; }
    }

    public class PagConsorcioListaDeCartoes
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string bandeira { get; set; }
        public string mascaracartao { get; set; }
        public string mascaracsv { get; set; }
        public string parcelamentomax { get; set; }
    }

    public class PagConsorcioListaOperadores
    {
        public string CodigoOperador { get; set; }
        public string Nome { get; set; }
    }
}