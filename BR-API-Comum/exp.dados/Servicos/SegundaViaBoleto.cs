using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace exp.dados
{
    [Serializable]
    [XmlRoot("SegundaViaBoleto")]
    public class gerarRespostaAtraso
    {
        [XmlArray("gerarResultadoAtraso")]
        [XmlArrayItem("stcGeraBAAtraso", typeof(SegundaViaBoleto))]
        public SegundaViaBoleto[] stcGeraBAAtraso { get; set; }
    }

    [Serializable]
    public class SegundaViaBoleto
    {
        [XmlElement("ID_Identificador")] public int ID_Identificador { get; set; }

        [XmlElement("NO_Parcela")] public int NO_Parcela { get; set; }

        [XmlElement("DT_Vencimento")] public DateTime DT_Vencimento { get; set; }

        [XmlElement("VL_Parcela")] public decimal? VL_Parcela { get; set; }

        [XmlElement("VL_MJ")] public decimal? VL_MJ { get; set; }

        [XmlElement("VL_Atraso")] public decimal? VL_Atraso { get; set; }

        [XmlElement("ErrMsg")] public string ErrMsg { get; set; }
    }

    public class BoletoModel
    {
        public dynamic ID_Identificador { get; set; }
        public dynamic ErrMsg { get; set; }
        public dynamic NO_Parcela { get; set; }
        public dynamic DT_Vencimento { get; set; }
        public dynamic VL_Parcela { get; set; }
        public dynamic VL_MJ { get; set; }
        public dynamic VL_Atraso { get; set; }
    }

    public class Boleto2ViaMensal
    {
        public dynamic ID_Identificador { get; set; }
        public dynamic NO_Parcela { get; set; }
        public dynamic DT_Vencimento { get; set; }
        public dynamic ID_Assembleia { get; set; }
        public dynamic VL_Parcela { get; set; }
        public dynamic VL_MJ { get; set; }
        public dynamic VL_Total { get; set; }
        public dynamic ErrMsg { get; set; }
    }
}