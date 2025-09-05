namespace exp.dados
{
    public class PessoaTelefoneModel
    {
        public PessoaTelefoneModel()
        {
            Return_Code = "0";
        }

        public string ID_Pessoa { get; set; }
        public string ID_Telefone { get; set; }
        public string ID_Cidade { get; set; }
        public string ID_UF { get; set; }
        public string ID_Tipo_Telefone { get; set; }
        public string Telefone { get; set; }
        public string NO_Sequencia { get; set; }
        public string Return_Code { get; set; }
        public string ErrMsg { get; set; }
    }
}