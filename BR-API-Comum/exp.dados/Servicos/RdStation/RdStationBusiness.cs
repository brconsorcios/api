using System;
using System.Collections.Generic;

namespace exp.dados.Servicos.RdStation
{
    public class RdStationBusiness
    {
        public enum Formulario
        {
            IndicacaoEmail,
            IndicacaoLigacao,
            IndicacaoVisita,
            IndicacaoRapida,
            BlackFriday2017
        }

        public static string RetornarIdentificador(Formulario formulario, int site)
        {
            //var formularioMapping = new Dictionary<Formulario, string>
            //{
            //    { Formulario.IndicacaoEmail, "Quero receber e-mail - " },
            //    { Formulario.IndicacaoLigacao, "Quero receber ligação - " },
            //    { Formulario.IndicacaoVisita, "Quero receber visita - " },
            //    { Formulario.IndicacaoRapida, "Fale fácil - " }
            //};
            

            var mapeamento = new Dictionary<int, Dictionary<Formulario, string>>
            {
                {
                    1, new Dictionary<Formulario, string>
                    {
                        { Formulario.IndicacaoRapida, "Fale fácil - SCP" },
                        { Formulario.IndicacaoVisita, "Quero receber visita - SCP" },
                        { Formulario.IndicacaoLigacao, "Quero receber ligação - SCP " },
                        { Formulario.IndicacaoEmail, "Quero receber e-mail - SCP " },
                        { Formulario.IndicacaoEmail, "Black Friday 2017 - SCP " }
                    }
                },
                {
                    2, new Dictionary<Formulario, string>
                    {
                        { Formulario.IndicacaoRapida, "Fale fácil" },
                        { Formulario.IndicacaoVisita, "Quero Receber Visita - SCP" },
                        { Formulario.IndicacaoLigacao, "Quero Receber Ligação - SCP " },
                        { Formulario.IndicacaoEmail, "Quero Receber E-mail - SCP " },
                        { Formulario.IndicacaoEmail, "Black Friday 2017 - SCP " }
                    }
                },
                {
                    5, new Dictionary<Formulario, string>
                    {
                        { Formulario.IndicacaoRapida, "Fale fácil - SCP" },
                        { Formulario.IndicacaoVisita, "Quero receber visita - SCP" },
                        { Formulario.IndicacaoLigacao, "Quero receber ligação - SCP" },
                        { Formulario.IndicacaoEmail, "Quero receber e-mail - SCP" },
                        { Formulario.IndicacaoEmail, "Black Friday 2017 - SCP " }
                    }
                },
                {
                    6, new Dictionary<Formulario, string>
                    {
                        { Formulario.IndicacaoRapida, "Fale fácil - SCP" },
                        { Formulario.IndicacaoVisita, "Quero receber visita - SCP" },
                        { Formulario.IndicacaoLigacao, "Quero receber ligação - SCP" },
                        { Formulario.IndicacaoEmail, "Quero receber e-mail - SCP" },
                        { Formulario.IndicacaoEmail, "Black Friday 2017 - SCP " }
                    }
                },
                {
                    8, new Dictionary<Formulario, string>
                    {
                        { Formulario.IndicacaoRapida, "Fale fácil - SCP" },
                        { Formulario.IndicacaoVisita, "Quero receber visita - SCP" },
                        { Formulario.IndicacaoLigacao, "Quero receber ligação - SCP" },
                        { Formulario.IndicacaoEmail, "Quero receber e-mail - SCP" },
                        { Formulario.IndicacaoEmail, "Black Friday 2017 - SCP " }
                    }
                },
                {
                    11, new Dictionary<Formulario, string>
                    {
                        { Formulario.IndicacaoRapida, "Fale Fácil - SCP" },
                        { Formulario.IndicacaoVisita, "Quero receber visita - SCP" },
                        { Formulario.IndicacaoLigacao, "Quero receber ligação - SCP" },
                        { Formulario.IndicacaoEmail, "Quero receber e-mail - SCP" }
                    }
                },
                {
                    12, new Dictionary<Formulario, string>
                    {
                        { Formulario.IndicacaoRapida, "Fale fácil - SCP" },
                        { Formulario.IndicacaoVisita, "Quero receber visita - SCP" },
                        { Formulario.IndicacaoLigacao, "Quero receber ligação - SCP" },
                        { Formulario.IndicacaoEmail, "Quero receber e-mail - SCP" }
                    }
                },
                {
                    13, new Dictionary<Formulario, string>
                    {
                        { Formulario.IndicacaoRapida, "Fale fácil - SCP" },
                        { Formulario.IndicacaoVisita, "Quero receber visita - SCP" },
                        { Formulario.IndicacaoLigacao, "Quero receber ligação - SCP" },
                        { Formulario.IndicacaoEmail, "Quero receber e-mail - SCP" },
                        { Formulario.IndicacaoEmail, "Black Friday 2017 - SCP " }
                    }
                }
            };

            try
            {
                return mapeamento[site][formulario];
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}