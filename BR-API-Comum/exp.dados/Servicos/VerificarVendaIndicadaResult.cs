using System;
using System.Collections.Generic;

namespace exp.dados.Servicos
{
    public class VerificarVendaIndicadaResult
    {
        public int Contrato { get; set; }

        public string Grupo { get; set; }

        public string Cota { get; set; }

        public int Versao { get; set; }

        public string NomeConsorciado { get; set; }

        public string CPFCNPJ { get; set; }

        public DateTime Datavenda { get; set; }

        public string Email { get; set; }

        public bool BateuCPF { get; set; }

        public bool BateuEmail { get; set; }

        public bool BateuNome { get; set; }

        public string CodComissionado { get; set; }

        public string NomeComissionado { get; set; }

        public string CodEquipeVenda { get; set; }

        public string NomeEquipe { get; set; }

        public string CamposChave
        {
            get
            {
                var campos = new List<string>();
                if (BateuCPF)
                    campos.Add("CPF/CNPJ");
                if (BateuEmail)
                    campos.Add("E-mail");
                if (BateuNome)
                    campos.Add("Nome");
                return string.Join(", ", campos);
            }
        }

        public List<int> IndicacaoIds { get; set; } = new List<int>();
    }
}