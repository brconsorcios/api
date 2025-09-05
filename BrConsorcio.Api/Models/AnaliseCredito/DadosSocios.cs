using System;
using System.ComponentModel.DataAnnotations;

namespace BrConsorcio.Api.Models.AnaliseCredito
{
    public class DadosSocios
    {
        public int ID_CORCC023CTMP { get; set; }

        [Display(Name = "ID Sócio")]
        [Required(ErrorMessage = "Identificador sócio deve ser preenchido")]
        public int ID_Pessoa_Socio { get; set; }

        public decimal PE_Participacao_Socio { get; set; }

        [Display(Name = "* Nome Sócio")]
        //[Required(ErrorMessage = "Nome sócio deve ser preenchido")]
        public string NM_Socio { get; set; }

        [Display(Name = "* CPF")]
        [Required(ErrorMessage = "CPF sócio deve ser preenchido")]
        public string CD_Inscricao_Nacional_Socio { get; set; }

        [Display(Name = "* Data de Entrada")]
        [Required(ErrorMessage = "Data de Entrada deve ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime DT_Entrada { get; set; }

        [Display(Name = "* Data de Nascimento")]
        [Required(ErrorMessage = "Data de Nascimento deve ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime DT_Nascimento { get; set; }

        [Display(Name = "* E-Mail")]
        //[Required(ErrorMessage = "E-Mail deve ser preenchido")]
        public string E_Mail { get; set; }

        [Display(Name = "* Sexo")]
        //[Required(ErrorMessage = "Sexo deve ser preenchido")]
        public string ST_Sexo_Socio { get; set; }

        [Display(Name = "* % de Participação")]
        //[Required(ErrorMessage = "% de Participação deve ser preenchido")]
        public string PE_Participacao_Socio_Formatado { get; set; }
    }
}