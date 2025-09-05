namespace exp.dados
{
    public class PessoaRetornoModel
    {
        public PessoaRetornoModel()
        {
            Return_Code = "0";
        }

        //public string ID_Endereco { get; set; }
        //public string ID_Telefone { get; set; }
        //public string ID_E_Mail { get; set; }
        public string ID_Pessoa { get; set; }
        public string Return_Code { get; set; }
        public string ErrMsg { get; set; }
    }
}