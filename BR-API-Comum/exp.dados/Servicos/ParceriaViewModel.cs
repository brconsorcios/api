using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace exp.dados
{
    public class ParceriaViewModel
    {
        public ParceriaViewModel()
        {
            representa = new List<Representa>();
            parenteSocio1 = false;
            parenteSocio2 = false;
            representanteSocio1 = false;
            representanteSocio2 = false;
            assconjSocio1 = false;
            assconjSocio2 = false;
        }

        // public int id { get; set; }
        [Required(ErrorMessage = "* Campo NOME FANTASIA obrigatório!")]
        public string nomeFantasia { get; set; }

        [Required(ErrorMessage = "* Campo RAZÃO SOCIAL obrigatório!")]
        public string razaoSocial { get; set; }

        [Required(ErrorMessage = "* Campo CNPJ obrigatório!")]
        public string cnpj { get; set; }

        [Required(ErrorMessage = "* Campo INSCRIÇÃO ESTADUAL obrigatório!")]
        public string inscEstadual { get; set; }

        [Required(ErrorMessage = "* Campo DATA DE FUNDAÇÃO obrigatório!")]
        public DateTime? fundadaem { get; set; }

        [Required(ErrorMessage = "* Campo ENDEREÇO COMERCIAL obrigatório!")]
        public string enderecoComercial { get; set; }

        public string complemento { get; set; }

        [Required(ErrorMessage = "* Campo BAIRRO obrigatório!")]
        public string bairro { get; set; }

        [Required(ErrorMessage = "* Campo CIDADE obrigatório!")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "* Campo UF obrigatório!")]
        public string uf { get; set; }

        [Required(ErrorMessage = "* Campo CEP obrigatório!")]
        public string cep { get; set; }

        [Required(ErrorMessage = "* Campo TELEFONE obrigatório!")]
        public string telefone { get; set; }

        public string celular { get; set; }

        [Required(ErrorMessage = "* Campo E-MAIL obrigatório!")]
        public string email1 { get; set; }

        public string email2 { get; set; }

        public List<Representa> representa { get; set; }

        #region ### SOCIO 1 ###

        [Required(ErrorMessage = "* Campo NOME obrigatório!")]
        public string nomeSocio1 { get; set; }

        [Required(ErrorMessage = "* Campo RG obrigatório!")]
        public string rgSocio1 { get; set; }

        [Required(ErrorMessage = "* Campo CPF obrigatório!")]
        public string cpfSocio1 { get; set; }

        [Required(ErrorMessage = "* Campo TELEFONE obrigatório!")]
        public string telefoneSocio1 { get; set; }

        [Required(ErrorMessage = "* Campo NOME DA MÃE obrigatório!")]
        public string maeSocio1 { get; set; }

        [Required(ErrorMessage = "* Campo NOME DO PAI obrigatório!")]
        public string paiSocio1 { get; set; }

        public bool? parenteSocio1 { get; set; }

        public string funcionarioSocio1 { get; set; }

        public string parentescoSocio1 { get; set; }

        public bool? representanteSocio1 { get; set; }

        public bool? assconjSocio1 { get; set; }

        #endregion

        #region ### SOCIO 2 ###

        //[Required(ErrorMessage = "* Campo NOME obrigatório!", AllowEmptyStrings = false)]
        public string nomeSocio2 { get; set; }

        //[Required(ErrorMessage = "* Campo RG obrigatório!", AllowEmptyStrings = false)]
        public string rgSocio2 { get; set; }

        //[Required(ErrorMessage = "* Campo CPF obrigatório!", AllowEmptyStrings = false)]
        public string cpfSocio2 { get; set; }

        //[Required(ErrorMessage = "* Campo TELEFONE obrigatório!", AllowEmptyStrings = false)]
        public string telefoneSocio2 { get; set; }

        //[Required(ErrorMessage = "* Campo NOME DA MÃE obrigatório!", AllowEmptyStrings = false)]
        public string maeSocio2 { get; set; }

        //[Required(ErrorMessage = "* Campo NOME DO PAI obrigatório!", AllowEmptyStrings = false)]
        public string paiSocio2 { get; set; }

        public bool? parenteSocio2 { get; set; }
        public string funcionarioSocio2 { get; set; }
        public string parentescoSocio2 { get; set; }
        public bool? representanteSocio2 { get; set; }
        public bool? assconjSocio2 { get; set; }

        #endregion
    }

    public class Representa
    {
        // public int id { get; set; }
        public int propostasID { get; set; }

        [Required(ErrorMessage = "* Campo NOME obrigatório!")]
        public string nome { get; set; }

        [Required(ErrorMessage = "* Campo ATIVIDADE obrigatório!")]
        public string atividade { get; set; }

        [Required(ErrorMessage = "* Campo CIDADE obrigatório!")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "* Campo UF obrigatório!")]
        public string uf { get; set; }

        [Required(ErrorMessage = "* Campo PERIODO obrigatório!")]
        public string periodo { get; set; }
    }
}