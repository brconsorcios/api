using System;

namespace exp.dados
{
    public class IndicacoesRelatorioModel
    {
        public string id_site { get; set; }
        public string area { get; set; }
        public string parceiro { get; set; }
        public string filial { get; set; }
        public string status { get; set; }
        public string tipo { get; set; }
        public DateTime dtinicio { get; set; }
        public DateTime dtfim { get; set; }
        public string order { get; set; }
    }


    public class IndicacoesExcelModel
    {
        private string _faixas;
        private string _tipo;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string CpfCnpj { get; set; }
        public string pais { get; set; }
        public string cidade { get; set; }
        public string id_documento { get; set; }
        public string uf { get; set; }

        public string Produto { get; set; }
        //public string pais { get; set; }


        public string Filial { get; set; }
        public string Vendedor { get; set; }
        public string Site { get; set; }
        public string Parceiro { get; set; }
        public DateTime datacadastro { get; set; }

        public string Tipo { get; set; } //ok 

        public string TipoDesc
        {
            get
            {
                if (Tipo != "")
                    _tipo = TiposIndicacao.ObterPorId(Convert.ToInt32(Tipo)).tipo;
                else
                    _tipo = Status;

                return _tipo;
            }
            set => _tipo = value;
        }

        // public Nullable<int> IdBem { get; set; }
        public string Bem { get; set; } //ok BemEscolhido
        public string Prazo { get; set; } //ok plano
        public decimal? Credito { get; set; } //ok credito
        public decimal? Parcela { get; set; } //ok parcelamensal

        public string Status { get; set; }

        public string StatusDesc
        {
            get
            {
                if (Status != "")
                    _faixas = StatusAtendimento.ObterPorId(Convert.ToInt32(Status)).status;
                else
                    _faixas = Status;

                return _faixas;
            }
            set => _faixas = value;
        }


        //public IndicacoesExcelModel()
        //{
        //    Status = StatusAtual;
        //    //if (Status != "")
        //    //{
        //    //    Status =  StatusAtendimento.ObterPorId(Convert.ToInt32(Status)).status;
        //    //}
        //}
    }
}