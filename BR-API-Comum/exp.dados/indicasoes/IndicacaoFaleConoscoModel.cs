using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using exp.core.Utilitarios;

namespace exp.dados
{
    public class IndicacaoFaleConoscoModel
    {
        public enum Assunto
        {
            [Description("Suporte à minha cota")] SuporteMinhaCota = 1,
            [Description("Sugestão/Reclamação")] SugestaoReclamacao = 2,
            [Description("Interesse em Carros")] InteresseCarros = 3,
            [Description("Interesse em Imóveis")] InteresseImoveis = 4,
            [Description("Interesse em Motos")] InteresseMotos = 5,

            [Description("Interesse em Caminhões")]
            InteresseCaminhoes = 6,
            [Description("Interesse em Serviços")] InteresseServicos = 7,

            [Description("Interesse em Máquinas e Equipamentos")]
            InteresseMaquinasEquipamentos = 8
        }

        public IndicacaoFaleConoscoModel()
        {
            //Fale Conosco
            tipo_indicacao = 5;
        }

        public int? tipo_indicacao { get; set; }
        public int? status { get; set; }

        [Display(Name = "Site")]
        [Required(ErrorMessage = "A Administradora Associada não foi selecionada.")]
        public virtual int? id_site { get; set; }

        //public string grupo { get; set; }
        //public string cota { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome está vazio ou contém caracteres inválidos.")]
        [StringLength(60, ErrorMessage = "Tamanho máximo de 60 caracteres.")] //,MinimumLength=3)]
        public virtual string nome { get; set; } //ok

        [Required(ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "O campo E-mail está vazio ou contém caracteres inválidos.")]
        public virtual string email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone está vazio ou contém caracteres inválidos.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Telefone é inválido.")]
        public virtual string telefone { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF está vazio ou contém caracteres inválidos.")]
        [ValidarCpf(ErrorMessage = "CPF inválido.")]
        public string cpfcnpj { get; set; }

        [Display(Name = "UF")]
        //[Required(ErrorMessage = "O campo Estado está vazio ou contém caracteres inválidos.")]
        public virtual string uf { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Selecione novamente o Estado, e digite o nome da cidade.")]
        [StringLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres.")]
        public string cidade { get; set; }

        public virtual string ds_cidade { get; set; }

        [Display(Name = "cd_cidade")] public int? cd_cidade { get; set; }

        //[Display(Name = "Celular")]
        //[Required(ErrorMessage = "O Celular está vazio ou contém caracteres inválidos.")]
        //[RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Número de Celular é inválido.")]
        //public virtual string celular { get; set; } 

        [Required(ErrorMessage = "Descreva a sua Mensagem.")]
        [StringLength(2000, MinimumLength = 1, ErrorMessage = "Limite de 2000 caracteres.")]
        public string comentario { get; set; }

        [Required(ErrorMessage = "Informe se ja é cliente.")]
        public bool? SouCliente { get; set; }

        //[RequiredIf("SouCliente == false", ErrorMessage = "AssuntoNSC obrigatorio")]
        //[EnumDataType(typeof(AssuntoNaoSouCliente), ErrorMessage = "Assunto inválido.")]
        [ValidarAssuntoAtribute]
        [Required(ErrorMessage = "Selecione o assunto.")]
        public Assunto? assunto { get; set; }

        public static Assunto[] AssuntosSC()
        {
            return new[]
            {
                Assunto.SuporteMinhaCota,
                Assunto.SugestaoReclamacao
            };
        }

        public static Assunto[] AssuntosNSC(int site_id)
        {
            if (site_id == 11 || site_id == 12 || site_id == 13)
                return new[]
                {
                    Assunto.InteresseCarros,
                    Assunto.InteresseImoveis,
                    Assunto.InteresseMotos,
                    Assunto.InteresseServicos,
                    Assunto.SugestaoReclamacao
                };

            return new[]
            {
                Assunto.InteresseCarros,
                Assunto.InteresseImoveis,
                Assunto.InteresseMotos,
                Assunto.InteresseCaminhoes,
                Assunto.InteresseServicos,
                Assunto.InteresseMaquinasEquipamentos,
                Assunto.SugestaoReclamacao
            };
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidarAssuntoAtribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var instance = validationContext.ObjectInstance;
                var type = instance.GetType();
                var SouCliente = (bool)type.GetProperty("SouCliente").GetValue(instance, null);
                var id_site = (int?)type.GetProperty("id_site").GetValue(instance, null);
                var assunto = (IndicacaoFaleConoscoModel.Assunto?)value;

                if (SouCliente)
                {
                    if (!IndicacaoFaleConoscoModel.AssuntosSC().Contains(assunto.Value))
                        return new ValidationResult(ErrorMessage);
                }
                else
                {
                    if (!IndicacaoFaleConoscoModel.AssuntosNSC(id_site.GetValueOrDefault()).Contains(assunto.Value))
                        return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}