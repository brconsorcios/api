using System;

namespace exp.dados
{
    //verificar grupo e cota e retornar identificados
    public class prcGeraBAParcelasResult
    {
        public string ID_Identificador { get; set; }
        public string ErrMsg { get; set; }
    }

    public class TransitoBoleto
    {
        public string id_identificador { get; set; }
        public string id_cobranca { get; set; }
        public string versao { get; set; }
        public string cd_grupo { get; set; }
        public string cd_cota { get; set; }
    }

    public class resultadoParcelas
    {
        public string ID_Identificador { get; set; }
        public string ID_Cobranca { get; set; } //14</ID_Cobranca>
        public string NO_Parcela { get; set; } //014</NO_Parcela>
        public DateTime? DT_Vencimento { get; set; } //2015-07-08T00:00:00</DT_Vencimento>
        public string ID_Assembleia { get; set; } //46738</ID_Assembleia>
        public decimal? VL_Paga { get; set; } //24.72</VL_Paga>
        public decimal? VL_MJ { get; set; } //0</VL_MJ>
        public decimal? VL_Pendencia { get; set; } //24.72</VL_Pendencia>
        public string SN_Emite_Boleto { get; set; } //N</SN_Emite_Boleto>
        public string ID_CD_Movto_Fin { get; set; } //356</ID_CD_Movto_Fin>

        public string NM_CD_Movto_Fin { get; set; } //PAGTO DE NOTIFICAÇÃO</NM_CD_Movto_Fin>
        //public string ErrMsg { get; set; }


        //<ID_Cobranca>24</ID_Cobranca>
        //<NO_Parcela>015</NO_Parcela>
        //<DT_Vencimento>2015-08-08T00:00:00</DT_Vencimento>
        //<ID_Assembleia>46739</ID_Assembleia>
        //<VL_Paga>49.47</VL_Paga>
        //<VL_MJ>0</VL_MJ>
        //<VL_Pendencia>49.47</VL_Pendencia>
        //<SN_Emite_Boleto>N</SN_Emite_Boleto>
        //<ID_CD_Movto_Fin>390</ID_CD_Movto_Fin>
        //<NM_CD_Movto_Fin>RECBTO DE GRAVAMES</NM_CD_Movto_Fin>
    }

    public class prcMarcaBAParcelaResult
    {
        public string ID_Identificador { get; set; }
        public string ErrMsg { get; set; } //string</ErrMsg>
        public string ID_Cobranca { get; set; } //int</ID_Cobranca>
        public string NO_Parcela { get; set; } //string</NO_Parcela>
        public DateTime? DT_Vencimento { get; set; } //dateTime</DT_Vencimento>
        public string ID_Assembleia { get; set; } //int</ID_Assembleia>
        public decimal? VL_Paga { get; set; } //double</VL_Paga>
        public decimal? VL_MJ { get; set; } //double</VL_MJ>
        public decimal? VL_Pendencia { get; set; } //double</VL_Pendencia>
        public string SN_Emite_Boleto { get; set; } //string</SN_Emite_Boleto>
        public string ID_CD_Movto_Fin { get; set; } //int</ID_CD_Movto_Fin>
        public string NM_CD_Movto_Fin { get; set; } //string</NM_CD_Movto_Fin>
    }

    public class prcConfirmaBAParcelasResult
    {
        public string ID_Identificador { get; set; }
        public string Return_Code { get; set; } //>0</Return_Code> ZERO é FOI CONFIRMADO COM SUCESSO
        public string Err_Msg { get; set; } //
    }
}