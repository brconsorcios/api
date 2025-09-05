using System.Collections.Generic;
using System.Linq;

namespace exp.dados
{
    public static class StatusAtendimento
    {
        private static IList<Status> _faixas;

        private static IList<Status> Faixas
        {
            get
            {
                if (_faixas == null)
                    Inicializar();
                return _faixas;
            }
            set => _faixas = value;
        }

        private static IList<Status> Inicializar()
        {
            _faixas = new List<Status>
            {
                new Status
                {
                    id = 0, status = "Não finalizadas",
                    descricao = "Cliente apenas iniciou o cadastro mas não finalizou"
                },
                new Status { id = 1, status = "Novas", descricao = "Recem cadastradas" },
                new Status { id = 2, status = "Negociação", descricao = "O Vendedor já está realizando o atendimento" },
                new Status
                {
                    id = 3, status = "Agendadas", descricao = "O CLiente pediu para contacta-lo em outra data"
                },
                new Status { id = 4, status = "Vendidas", descricao = "" },
                new Status { id = 5, status = "Canceladas", descricao = "" },
                new Status
                {
                    id = 6, status = "Em atraso", descricao = "Indicação não foi atualizada no prazo de 48 horas"
                }
            };
            return _faixas;
        }

        public static List<Status> ObterTodos()
        {
            return Faixas.OrderBy(x => x.id).ToList();
        }

        public static Status ObterPorId(int id)
        {
            return ObterTodos().FirstOrDefault(b => b.id == id);
        }

        public struct Status
        {
            public int id { get; set; }
            public string status { get; set; }
            public string descricao { get; set; }
        }
    }
}