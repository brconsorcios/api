using System;

namespace exp.dados
{
    public class ouvidoria
    {
        public int id { get; set; }

        public string n_protocolo { get; set; }

        public string nome_razaosocial { get; set; }

        public string cpf_cnpj { get; set; }

        public string email { get; set; }

        public string grupo { get; set; }

        public string cota { get; set; }

        public string assunto { get; set; }

        public string mensagem { get; set; }

        public int id_site { get; set; }

        public string endereco_ip { get; set; }

        public DateTime dt_cadastro { get; set; }


        public site site { get; set; }
    }
}