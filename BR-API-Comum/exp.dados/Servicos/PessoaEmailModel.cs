namespace exp.dados
{
    public class PessoaEmailModel
    {
        public PessoaEmailModel()
        {
            Return_Code = "0";
        }

        public string ID_Pessoa { get; set; }
        public string ID_E_Mail { get; set; }
        public string E_Mail { get; set; }
        public string NO_Sequencia { get; set; }
        public string Return_Code { get; set; }
        public string ErrMsg { get; set; }
    }
}