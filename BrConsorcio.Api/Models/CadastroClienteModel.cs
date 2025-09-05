using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class CadastroClienteModel : ClienteModel
    {
        [Required]
        public int IdBem { get; set; }
        [Required]
        public short PzComercializacao { get; set; }
        [Required]
        public int IdPlanoVenda { get; set; }
        [Required]
        public int IdTaxaPlano { get; set; }

        public string aut_fone { get; set; }
        public string aut_end { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string celular { get; set; }
        public string socio_estado_civil { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? socio_nasc { get; set; }
        public string socio_sexo { get; set; }
        public string aut_mail { get; set; }
        public int id_site { get; set; }
        public string shc { get; set; }
        public string profissao { get; set; }
        public string socio_cpf { get; set; }
        public string socio_nome { get; set; }
        public string chave { get; set; }
        //public int id_ben { get; set; }
        public string cidade { get; set; }
        public string aut_renda { get; set; }
    }
}
