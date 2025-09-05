using System;
using System.ComponentModel.DataAnnotations;
using exp.core;

namespace exp.dados
{
    public class PessoaIdentificaModel
    {
        private string _cpfcnpj;

        public PessoaIdentificaModel()
        {
            confirmar = false;
            id_site = 0;
        }

        [Display(Name = "CPF/CNPJ")]
        [Required(ErrorMessage = "O campo CPF/CNPJ está vazio ou contém caracteres inválidos.")]
        [StringLength(14, ErrorMessage = "Tamanho máximo de 14 caracteres.")] //,MinimumLength=3)]
        public string cpfcnpj
        {
            get => _cpfcnpj;
            set => _cpfcnpj = value.RetirarAlfabeto();
        }

        [DataType(DataType.DateTime, ErrorMessage = "Informe uma data válida.")]
        public DateTime? dt_nascfund { get; set; }

        [Display(Name = "Tipo Pessoa")] public string tipo { get; set; }

        public string chave { get; set; }
        public bool confirmar { get; set; }

        //utilizado no site da br
        public int id_site { get; set; }

        public string hash_verificador { get; set; }

        public string Tipo()
        {
            var tipopessoa = "F";
            if (!string.IsNullOrEmpty(cpfcnpj))
                if (cpfcnpj.Length > 11)
                    tipopessoa = "J";

            return tipopessoa;
        }
    }
}