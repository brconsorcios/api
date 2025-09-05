using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class ClienteModel
    {

        public string nome_banco { get; set; }
        public cliente_email cliente_email { get; set; }
        public cliente_fone cliente_fone { get; set; }
        public cliente_end cliente_end { get; set; }
        public cliente_pj cliente_pj { get; set; }
        public cliente_pf cliente_pf { get; set; }
        public bool exibirconta { get; set; }
        public decimal vl_rendacapital { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? dt_nascfund { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        [StringLength(60, ErrorMessage = "Tamanho máximo de 60 caracteres.")]
        public string nome { get; set; }
        //[Display(Name = "Senha")]
        //[Required(ErrorMessage = "O campo Senha está vazio ou contém caracteres inválidos.")]
        //[StringLength(50, ErrorMessage = "Tamanho mínimo é 10 e o máximo de 50 caracteres.", MinimumLength = 10)]
        public string sh { get; set; }
        public int id_tipo_documento { get; set; }
        public string no_documento { get; set; }
        public string cd_inscricao_nacional { get; set; }
        public string sn_politicamente_exposto { get; set; }
        public string cd_pessoa { get; set; }
        [Display(Name = "Tipo Pessoa")]
        [Required]
        public string st_tipo_pessoa { get; set; }
        public int id_pessoa { get; set; }
        public int id { get; set; }
        public string agencia { get; set; }
        public string numero_conta { get; set; }
    }

    public class cliente_email
    {


        public int id_cliente { get; set; }
        public int id_email { get; set; }
        [DataType(DataType.EmailAddress)]
        public string e_mail { get; set; }
        //public ClienteModel cliente { get; set; }
    }
    public class cliente_fone
    {

        public int id_cliente { get; set; }
        public int id_telefone { get; set; }
        public int id_cidade { get; set; }
        public string id_uf { get; set; }
        public int id_tipo_telefone { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string telefone { get; set; }
        public int no_sequencia { get; set; }
        public string ddd { get; set; }
        public int id_celular { get; set; }
        public int id_cidade_celular { get; set; }
        public string id_uf_celular { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string celular { get; set; }
        public string ddd_celular { get; set; }
        //public ClienteModel cliente { get; set; }
    }

    public class cliente_end
    {

        public string ds_referencia_endereco { get; set; }
        public string caixa_postal { get; set; }
        public string nm_tipo_endereco { get; set; }
        public int id_tipo_endereco { get; set; }
        public int id_cidade { get; set; }
        public int id_endereco { get; set; }
        public int no_sequencia { get; set; }
        public string cep { get; set; }
        public string nm_cidade { get; set; }
        public string bairro { get; set; }
        public string complemento { get; set; }
        public string no_endereco { get; set; }
        public string endereco { get; set; }
        public int id_cliente { get; set; }
        public string id_uf { get; set; }
        //public ClienteModel cliente { get; set; }
    }

    public class cliente_pj
    {


        public int id_cliente { get; set; }
        public decimal vl_faturamento_medio { get; set; }
        public int id_pessoa_socio { get; set; }
        public string cargo_socio { get; set; }
        public decimal pe_participacao_socio { get; set; }
        public string observacao { get; set; }
        public string nm_socio { get; set; }
        public string cpf_socio { get; set; }
        public string sexo_socio { get; set; }
        public DateTime? dt_nasc_socio { get; set; }
        public string estado_civil_socio { get; set; }
        public int id_estado_civil { get; set; }
        public string celular_socio { get; set; }
        //public ClienteModel cliente { get; set; }


    }

    public class cliente_pf
    {

        public int id_cliente { get; set; }
        public DateTime? dt_expedicao { get; set; }
        public string nm_orgao_emissor { get; set; }
        public string st_sexo { get; set; }
        public int id_estado_civil { get; set; }
        public string nm_estado_civil { get; set; }
        public string nm_nacionalidade { get; set; }
        public string naturalidade { get; set; }
        public int id_profissao { get; set; }
        public string profissao { get; set; }
        public int id_regime_casamento { get; set; }
        public int id_pessoa_conjuge { get; set; }
        public DateTime? dt_casamento { get; set; }
        //public ClienteModel cliente { get; set; }


    }
}
