using System;

namespace exp.dados
{
    public class VendedorResult
    {
        public string CD_Usuario { get; set; }
        public string CD_Usuario_Externo { get; set; }
        public string NM_Pessoa { get; set; }
        public string ID_Usuario { get; set; }
        public string ID_Ponto_Venda { get; set; }
        public string ID_Comissionado { get; set; }
        public string CELULAR { get; set; }
        public string TELEFONE { get; set; }
        public string EMAIL { get; set; }
    }

    public class CidadeResult
    {
        public string ID_Cidade { get; set; }
        public string NM_Cidade { get; set; }
        public string ID_UF { get; set; }
        public string DDD { get; set; }
    }


    public class ValidarGrupoResult
    {
        public string CD_Grupo { get; set; }
        public string ST_Situacao { get; set; }
        public string id_adm { get; set; }
    }

    public class SituacaoGrupoResult
    {
        public int ID_Grupo { get; set; }
        public string CD_Grupo { get; set; }
        public string ST_Situacao { get; set; }
        public DateTime? DT_Assembleia_Atual { get; set; }
        public int ID_Plano_Venda { get; set; }
        public int ID_Taxa_Plano { get; set; }
        public int PZ_Comercializacao { get; set; }
        public int NO_Assembleia_Atual { get; set; }
        public int Meses_Restantes { get; set; }
        public decimal PE_TA { get; set; }
        public decimal PE_FR { get; set; }
        public decimal PE_SG { get; set; }
        public int Indice_Reajuste { get; set; }
        public int Empresa { get; set; }
        public string NM_Caracteristica { get; set; }

        public string SN_Produto_Principal { get; set; }

        public DateTime? DH_Formacao { get; set; }
    }

    public class GrupoStatusJson
    {
        public string status { get; set; } // varchar(50) DEFAULT NULL,
        public DateTime? dt_atualizacao { get; set; } // datetime DEFAULT NULL,
        public string chave { get; set; } // varchar(255) DEFAULT NULL,
        public long identificador { get; set; } // varchar(50) DEFAULT NULL,
    }


    public class AssembleiaCotaResult
    {
        public string CD_Grupo { get; set; }
        public string CD_Cota { get; set; }
        public string Versao { get; set; }
        public DateTime? DT_Contemplacao { get; set; }
        public string ST_Contemplacao { get; set; }
    }

    public class AssembleiaGrupoResult
    {
        public DateTime? DT_Assembleia { get; set; }
        public string HR_Assembleia { get; set; }
        public string MN_Assembleia { get; set; }
        public string NO_Maximo_Cota { get; set; }
        public string CD_Grupo { get; set; }
        public string ID_Local { get; set; }
        public string PZ_Comercializacao { get; set; }
    }

    public class AssembleiaResult
    {
        public DateTime? DT_Assembleia { get; set; }
        public string CD_Grupo { get; set; }
    }

    public class ConsultarVagaGrupoResult
    {
        public int ID_Grupo { get; set; }
        public string CD_Grupo { get; set; }
        public int QT_Cota_Vaga { get; set; }
    }

    public class ConsultarAssembleiaResult
    {
        public int ID_Assembleia { get; set; }
        public int ID_Grupo { get; set; }
        public DateTime DT_Assembleia { get; set; }
        public DateTime DT_Vencimento { get; set; }
        public string ST_Tipo_Sorteio { get; set; }
        public DateTime? DT_Sorteio { get; set; }
    }

    public class ConsultarPlanoVendaUnidadeResult
    {
        //public int id_plano_venda_site { get; set; }
        //public int id_site { get; set; }
        public int ID_Unidade_Negocio { get; set; }
        public string CD_Unidade_Negocio { get; set; }
        public int ID_Plano_Venda { get; set; }
        public DateTime DtInicioVigencia { get; set; }
        public DateTime DtFinalVigencia { get; set; }
    }
}