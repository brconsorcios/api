using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models.AnaliseCredito
{
    public class DadosClientePF
    {
        public int ID_CORCC023TMP { get; set; }
        public int ID_CORCC027TMP { get; set; }
        public int ID_CORCC030TMP { get; set; }

        public int ID_CORCC023LTMP { get; set; }
        public int ID_CORCC023L { get; set; }

        public int ID_CORCC023HTMP { get; set; }
        public int ID_Profissao { get; set; }
        public int ID_Pessoa_Empresa { get; set; }
        public string SN_Avalista { get; set; }

        // Dados para Identificação
        [Display(Name = "ID Cota")]
        [Required(ErrorMessage = "Identificador deve ser preenchido")]
        public string idCota { get; set; }

        [Display(Name = "ID Pessoa")]
        [Required(ErrorMessage = "Identificador deve ser preenchido")]
        public int idPessoa { get; set; }

        [Display(Name = "Identificador")]
        [Required(ErrorMessage = "Identificador deve ser preenchido")]
        public int idIdentificador { get; set; }

        [Display(Name = "CD Empresa")]
        public string cdEmpresa { get; set; }

        [Display(Name = "CD Usuario")]
        public string cdUsuario { get; set; }

        [Display(Name = "Observacao")]
        public string observacao { get; set; }

        [Display(Name = "* CPF")]
        [Required(ErrorMessage = "CPF deve ser preenchido")]
        public string cpf { get; set; }

        [Display(Name = "* Nome")]
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        public string nome { get; set; }

        [Display(Name = "* Data de Nascimento")]
        [Required(ErrorMessage = "Data de Nascimento deve ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2500", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime dataNascimento { get; set; }

        [Display(Name = "* RG")]
        [Required(ErrorMessage = "Documento deve ser preenchido")]
        public string documento { get; set; }

        [Display(Name = "* Orgão Emissor")]
        [Required(ErrorMessage = "Orgão Emissor deve ser preenchido")]
        public string orgaoEmissor { get; set; }

        [Display(Name = "* Nacionalidade")]
        [Required(ErrorMessage = "Nacionalidade deve ser preenchido")]
        public string nacionalidade { get; set; }

        [Display(Name = "* UF Naturalidade")]
        [Required(ErrorMessage = "UF Naturalidade deve ser preenchido")]
        public string ufNaturalidade { get; set; }

        [Display(Name = "* Naturalidade")]
        [Required(ErrorMessage = "Naturalidade deve ser preenchido")]
        public string naturalidade { get; set; }

        [Display(Name = "* Nome do Pai")]
        [Required(ErrorMessage = "Nome do Pai deve ser preenchido")]
        public string nomePai { get; set; }

        [Display(Name = "* Nome da Mãe")]
        [Required(ErrorMessage = "Nome do Mãe deve ser preenchido")]
        public string nomeMae { get; set; }

        [Display(Name = "* Sexo")]
        [Required(ErrorMessage = "Sexo deve ser preenchido")]
        public string sexo { get; set; }

        [Display(Name = "* Estado Civil")]
        [Required(ErrorMessage = "Estado Civil deve ser preenchido")]
        public string estadoCivil { get; set; }

        [Display(Name = "* CEP")]
        [Required(ErrorMessage = "CEP deve ser preenchido")]
        public string cep { get; set; }

        [Display(Name = "* Logradouro")]
        [Required(ErrorMessage = "Logradouro deve ser preenchido")]
        public string logradouro { get; set; }

        [Display(Name = "* Número")]
        [Required(ErrorMessage = "Número Logradouro deve ser preenchido")]
        public string nroLogradouro { get; set; }

        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        [Display(Name = "* Bairro")]
        [Required(ErrorMessage = "Bairro deve ser preenchido")]
        public string bairro { get; set; }

        [Display(Name = "Caixa Postal")]
        public string caixaPostal { get; set; }

        [Display(Name = "* Estado")]
        [Required(ErrorMessage = "Estado deve ser preenchido")]
        public string estado { get; set; }

        [Display(Name = "* Cidade")]
        [Required(ErrorMessage = "Cidade deve ser preenchido")]
        public string cidade { get; set; }

        [Display(Name = "* DDD")]
        [Required(ErrorMessage = "DDD deve ser preenchido")]
        public string dddTelefone { get; set; }

        [Display(Name = "* Telefone")]
        [Required(ErrorMessage = "Número Telefone deve ser preenchido")]
        public string nroTelefone { get; set; }

        [Display(Name = "DDD")]
        public string dddCelular { get; set; }

        [Display(Name = "Celular")]
        public string nroCelular { get; set; }

        [Display(Name = "* E-Mail")]
        [Required(ErrorMessage = "E-Mail deve ser preenchido")]
        public string eMail { get; set; }

        [Display(Name = "* Tipo de Residência")]
        [Required(ErrorMessage = "Tipo de Residência deve ser preenchido")]
        public string tipoResidencia { get; set; }

        [Display(Name = "* Dependentes")]
        [Required(ErrorMessage = "Número de dependentes deve ser preenchido")]
        public int dependentes { get; set; }

        // Dados Profissionais
        [Display(Name = "* Empresa onde Trabalha")]
        [Required(ErrorMessage = "Empresa deve ser preenchido")]
        public string empresa { get; set; }

        [Display(Name = "* Ramo Atividade")]
        [Required(ErrorMessage = "Ramo Atividade deve ser preenchido")]
        public string ramo { get; set; }

        [Display(Name = "* Cargo")]
        [Required(ErrorMessage = "Cargo Atividade deve ser preenchido")]
        public string cargo { get; set; }

        [Display(Name = "Grupos")]
        //[Required(ErrorMessage = "Grupo Profissão deve ser preenchido")]
        public string gruposProfissao { get; set; }

        [Display(Name = "Profissão")]
        //[Required(ErrorMessage = "Profissão deve ser preenchido")]
        public string profissao { get; set; }

        [Display(Name = "* Data Admissão")]
        [Required(ErrorMessage = "Data Admissão deve ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2500", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime dataAdmissao { get; set; }

        [Display(Name = "* Salário Mensal")]
        [Required(ErrorMessage = "Salário Mensal deve ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Valor inválido")]
        public decimal salarioMensal { get; set; }

        [Display(Name = "* Salário Mensal")]
        [Required(ErrorMessage = "Salário Mensal deve ser preenchido")]
        public string salarioMensalFormatado { get; set; }

        [Display(Name = "* UF")]
        //[Required(ErrorMessage = "UF endereço empresa deve ser preenchido")]
        public string ufEmpresa { get; set; }

        [Display(Name = "* Cidade")]
        //[Required(ErrorMessage = "Cidade endereço empresa deve ser preenchido")]
        public string cidadeEmpresa { get; set; }

        [Display(Name = "* DDD")]
        //[Required(ErrorMessage = "DDD deve ser preenchido")]
        public string dddTelEmpresa { get; set; }

        [Display(Name = "* Telefone")]
        //[Required(ErrorMessage = "Telefone empresa deve ser preenchido")]
        public string telefoneEmpresa { get; set; }

        [Display(Name = "* Outras Rendas")]
        [Required(ErrorMessage = "Outras Rendas deve ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Valor inválido")]
        public decimal outrasRendas { get; set; }

        [Display(Name = "* Outras Rendas")]
        [Required(ErrorMessage = "Outras Rendas deve ser preenchido")]
        public string outrasRendasFormatado { get; set; }

        // Dados do Conjuge
        [Display(Name = "Nome")]
        public string conjugeNome { get; set; }

        [Display(Name = "RG")]
        public string conjugeRG { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2500", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime conjugeDataNascimento { get; set; }

        [Display(Name = "CPF")]
        public string conjugeCPF { get; set; }

        [Display(Name = "Nacionalidade")]
        public string conjugeNacionalidade { get; set; }

        [Display(Name = "UF Naturalidade")]
        public string conjugeUfNaturalidade { get; set; }

        [Display(Name = "Naturalidade")]
        public string conjugeNaturalidade { get; set; }

        [Display(Name = "Empresa")]
        public string conjugeEmpresa { get; set; }

        [Display(Name = "Cargo")]
        public string conjugeCargo { get; set; }

        [Display(Name = "Grupos")]
        public string conjugeGrProfissao { get; set; }

        [Display(Name = "Profissão")]
        public string conjugeProfissao { get; set; }

        [Display(Name = "Data Admissão")]
        [Required(ErrorMessage = "Data de Nascimento deve ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2500", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]

        public DateTime conjugeDataAdmissao { get; set; }

        [Display(Name = "Salário Mensal")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Valor inválido")]
        public decimal conjugeSalarioMensal { get; set; }

        [Display(Name = "Salário Mensal")]
        public string conjugeSalarioMensalFormatado { get; set; }

        [Display(Name = "E-Mail")]
        public string conjugeEMail { get; set; }

        // Dados para a Declaração de Responsabilidade
        [Display(Name = "Aceito")]
        public bool declaracaoAceite { get; set; }

        // Dados para o Topo
        [Display(Name = "Grupo")]
        public string grupo { get; set; }

        [Display(Name = "Cota")]
        public string cota { get; set; }

        [Display(Name = "Bem")]
        public string bem { get; set; }

        [Display(Name = "Fase")]
        public string fase { get; set; }

        [Display(Name = "Contemp")]
        [Required(ErrorMessage = "Data de Nascimento deve ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2500", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime contemp { get; set; }

        [Display(Name = "Crédito")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Valor inválido")]
        public decimal credito { get; set; }

        [Display(Name = "Crédito")]
        public string creditoFormatado { get; set; }

        //Relacionamento com outros Modelos
        public virtual ICollection<FaturamentoProdutos> FaturamentoProdutos { get; set; }
        public virtual ICollection<DadosSocios> DadosSocios { get; set; }
        public virtual ICollection<ReferenciasClientes> ReferenciasClientes { get; set; }
        public virtual ICollection<DadosPatrimoniais> DadosPatrimoniais { get; set; }
        public virtual ICollection<DadosVeiculos> DadosVeiculos { get; set; }
        public virtual ICollection<DadosAvalista> DadosAvalista { get; set; }
    }
}
