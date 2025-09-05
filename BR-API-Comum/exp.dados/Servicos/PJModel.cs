namespace exp.dados
{
    public class PJModel
    {
        public PessoaJuridicaModel Juridica { get; set; }
        public PessoaFisicaModel Socio { get; set; }
        public PessoaEnderecoModel Endereco { get; set; }
        public PessoaEmailModel Email { get; set; }
        public PessoaTelefoneModel Telefone { get; set; }
        public PessoaTelefoneModel Celular { get; set; }
    }
}