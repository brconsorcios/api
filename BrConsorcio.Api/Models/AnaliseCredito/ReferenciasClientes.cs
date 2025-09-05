using System.ComponentModel.DataAnnotations;

namespace BrConsorcio.Api.Models.AnaliseCredito
{
    public class ReferenciasClientes
    {
        public int ID_CORCC023DTMP { get; set; }
        //ID_CORCC023D
        public int ID_CORCC023D { get; set; }
        //ID_Cidade_Referencia
        public int ID_Cidade_Referencia { get; set; }
        //Observacao
        public string Observacao { get; set; }
        //ST_Operacao
        public string ST_Operacao { get; set; }
        //ID_CORCC023D
        [Display(Name = "ID")]
        [Required(ErrorMessage = "Identificador deve ser preenchido")]
        public long Id { get; set; }

        [Display(Name = "* Tipo")]
        [Required(ErrorMessage = "Tipo devem ser preenchido")]
        public string tipo { get; set; }

        [Display(Name = "* Nome Referência")]
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        public string Nome { get; set; }

        [Display(Name = "* DDD")]
        [Required(ErrorMessage = "DDD Telefone deve ser preenchido")]
        public string dddTelefone { get; set; }

        [Display(Name = "* Telefone")]
        [Required(ErrorMessage = "Número Telefone deve ser preenchido")]
        public string nroTelefone { get; set; }

        [Display(Name = "* Logradouro")]
        [Required(ErrorMessage = "Logradouro deve ser preenchido")]
        public string logradouro { get; set; }

        [Display(Name = "* Número")]
        [Required(ErrorMessage = "Número Logradouro deve ser preenchido")]
        public string nroLogradouro { get; set; }
    }
}