using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class PessoaModel
    {

        public int Id { get; set; }
        public int IdConjuge { get; set; }

        public string PoliticamenteExposto { get; set; }

        public string Nome { get; set; }

        public string InscricaoNacional { get; set; }

        public string NrDocumento { get; set; }

        public int IdTipoDocumento { get; set; }

        public DateTime DtExpedicao { get; set; }
        public string NomeOrgaoEmissor { get; set; }

        public DateTime DtNascimentoFundacao { get; set; }

        public string Sexo { get; set; }

        public int IdEstadoCivil { get; set; }

        public string Nacionalidade { get; set; }

        public string Naturalidade { get; set; }


        public int IdProfissao { get; set; }

        public double ValorRenda { get; set; }

        public int IdRegimeCasamento { get; set; }

        public DateTime DtCasamento { get; set; }

        public string NomeMae { get; set; }

        public string NomeFantasia { get; set; }

        public string Observacao { get; set; }

        public double ValorCapitalSocial { get; set; }
        public double ValorFaturamentoMedio { get; set; }
        public int IdNaturezaJuridica { get; set; }
        public int IdAtividade { get; set; }
        public int IdSocio { get; set; }
        public string CargoSocio { get; set; }
        public double ParticipacaoSocio { get; set; }
        public string InscricaoNacionalSocio { get; set; }
        public string TipoPessoaSocio { get; set; }

        



    }
}
