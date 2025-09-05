namespace exp.dados
{
    public class PessoaEnderecoModel
    {
        public PessoaEnderecoModel()
        {
            Return_Code = "0";
        }

        public string ID_Endereco { get; set; }
        public string ID_Pessoa { get; set; }
        public string ID_Cidade { get; set; }
        public string ID_Tipo_Endereco { get; set; }
        public string NM_Tipo_Endereco { get; set; }
        public string NM_Cidade { get; set; }
        public string ID_UF { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string NO_Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Caixa_Postal { get; set; }
        public string DS_Referencia_Endereco { get; set; }
        public string NO_Sequencia { get; set; }
        public string Return_Code { get; set; }
        public string ErrMsg { get; set; }
    }
}