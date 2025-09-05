using System.Collections.Generic;
using System.Linq;

namespace exp.dados
{
    public static class TiposIndicacao
    {
        private static IList<Tipos> _faixas;

        private static IList<Tipos> Faixas
        {
            get
            {
                if (_faixas == null)
                    Inicializar();
                return _faixas;
            }
            set => _faixas = value;
        }

        private static IList<Tipos> Inicializar()
        {
            _faixas = new List<Tipos>
            {
                new Tipos { id = 0, tipo = "Cliente não finalizou", descricao = "" },
                new Tipos { id = 1, tipo = "Quero Comprar pela Internet", descricao = "" },
                new Tipos { id = 2, tipo = "Quero Receber uma visita", descricao = "" },
                new Tipos { id = 3, tipo = "Quero Receber uma ligação", descricao = "" },
                new Tipos { id = 4, tipo = "Quero Receber um E-mail", descricao = "" },
                new Tipos { id = 5, tipo = "Fale Conosco", descricao = "" },
                new Tipos { id = 6, tipo = "Ligamos para você", descricao = "" },
                new Tipos { id = 7, tipo = "Email ou Telefone - Meu Patrimônio", descricao = "" },
                new Tipos { id = 8, tipo = "Agenda - Meu Patrimônio", descricao = "" },
                new Tipos { id = 9, tipo = "Fale Fácil", descricao = "" },
                new Tipos { id = 10, tipo = "Compra Rápida", descricao = "" },
                new Tipos { id = 20, tipo = "Simulação - Hotsite Sinnapse", descricao = "" },
                new Tipos { id = 21, tipo = "Fale Conosco - Hotsite Sinnapse", descricao = "" },
                new Tipos { id = 22, tipo = "Black Friday 2017", descricao = "" },
                new Tipos { id = 23, tipo = "Simulação - Hotsite Giacometti", descricao = "" },
                new Tipos { id = 24, tipo = "Ligamos para você - Hotsite Giacometti", descricao = "" },
                new Tipos { id = 25, tipo = "Mande sua duvida - Hotsite Giacometti", descricao = "" },
                new Tipos { id = 26, tipo = "Preciso de ajuda - Hotsite Giacometti", descricao = "" },
                new Tipos { id = 27, tipo = "Venda Online da Desencana", descricao = "" }
            };
            return _faixas;
        }

        public static List<Tipos> ObterTodos()
        {
            return Faixas.OrderBy(x => x.id).ToList();
        }

        public static Tipos ObterPorId(int id)
        {
            return ObterTodos().FirstOrDefault(b => b.id == id);
        }

        public struct Tipos
        {
            public int id { get; set; }
            public string tipo { get; set; }
            public string descricao { get; set; }
        }
    }

    public enum TipoIndicacao
    {
        NaoFinalizou = 0,
        ComprarInternet = 1,
        ReceberVisita = 2,
        ReceberLigacao = 3,
        ReceberEmail = 4,
        FaleConosco = 5,
        LigamosParaVoce = 6,
        EmailTelefoneMeuPatrimonio = 7,
        AgendaMeuPatrimonio = 8,
        FaleFacil = 9,
        CompraRapida = 10,
        SimulacaoHotsiteSinnapse = 20,
        FaleConoscoHotsiteSinnapse = 21,
        BlackFriday2017 = 22,
        SimulacaoHotsiteGiacometti = 23,
        LigamosHotsiteGiacometti = 24,
        MandeDuvidaHotsiteGiacometti = 25,
        PrecisoAjudaHotsiteGiacometti = 26,
        VendaDesencana = 27
    }
}