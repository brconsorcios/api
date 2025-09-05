using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models.AnaliseCredito
{
    public class DadosClientePJ
    {
        public int ID_CORCC023TMP { get; set; }
        public int ID_CORCC023BTMP { get; set; }
        public int ID_CORCC026TMP { get; set; }
        public int ID_CORCC027TMP { get; set; }
        public int ID_CORCC027TMP_FAX { get; set; }
        public int ID_CORCC030TMP { get; set; }

        public string SN_Avalista { get; set; }

        [Display(Name = "* Tipo de Residência")]
        [Required(ErrorMessage = "Tipo de Residência deve ser preenchido")]
        public string tipoResidencia { get; set; }

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

        [Display(Name = "* CNPJ")]
        [Required(ErrorMessage = "CNPJ deve ser preenchido")]
        public string cnpj { get; set; }

        [Display(Name = "* Nome")]
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        public string nome { get; set; }

        [Display(Name = "* Nome Fantasia")]
        [Required(ErrorMessage = "Nome Fantasia deve ser preenchido")]
        public string nomeFantasia { get; set; }

        [Display(Name = "* Razão Social")]
        [Required(ErrorMessage = "Razão Social deve ser preenchido")]
        public string razaoSocial { get; set; }

        [Display(Name = "* Inscrição Estadual")]
        [Required(ErrorMessage = "Inscrição Estadual deve ser preenchido")]
        public string inscricaoEstadual { get; set; }

        [Display(Name = "* Logradouro (sede social)")]
        [Required(ErrorMessage = "Logradouro (sede social) deve ser preenchido")]
        public string logradouroSede { get; set; }

        [Display(Name = "* Número")]
        [Required(ErrorMessage = "Número Logradouro deve ser preenchido")]
        public string nroLogradouro { get; set; }

        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        [Display(Name = "* Bairro")]
        [Required(ErrorMessage = "Bairro deve ser preenchido")]
        public string bairro { get; set; }

        [Display(Name = "* CEP")]
        [Required(ErrorMessage = "CEP deve ser preenchido")]
        public string cep { get; set; }

        [Display(Name = "Caixa Postal")]
        public string caixaPostal { get; set; }

        [Display(Name = "* Estado")]
        [Required(ErrorMessage = "Estado deve ser preenchido")]
        public string estado { get; set; }

        [Display(Name = "* Cidade")]
        [Required(ErrorMessage = "Cidade deve ser preenchido")]
        public string cidade { get; set; }

        [Display(Name = "* DDD")]
        [Required(ErrorMessage = "DDD Telefone deve ser preenchido")]
        public string dddTelefone { get; set; }

        [Display(Name = "* Telefone")]
        [Required(ErrorMessage = "Número Telefone deve ser preenchido")]
        public string nroTelefone { get; set; }

        [Display(Name = "DDD")]
        public string dddFax { get; set; }

        [Display(Name = "Fax")]
        public string nroFax { get; set; }

        [Display(Name = "Capital Social")]
        public string capitalSocialFormatado { get; set; }

        [Display(Name = "* Capital Social")]
        [Required(ErrorMessage = "Capital Social deve ser preenchido")]
        public decimal capitalSocial { get; set; }

        [Display(Name = "* Faturamento Médio Mensal")]
        [Required(ErrorMessage = "Faturamento Médio Mensal deve ser preenchido")]
        public string faturamentoMensalFormatado { get; set; }

        [Display(Name = "* Faturamento Médio Mensal")]
        [Required(ErrorMessage = "Faturamento Médio Mensal deve ser preenchido")]
        public decimal faturamentoMensal { get; set; }

        [Display(Name = "* E-Mail")]
        [Required(ErrorMessage = "E-Mail deve ser preenchido")]
        public string EMail { get; set; }

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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
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
