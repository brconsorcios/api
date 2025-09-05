namespace exp.dados
{
    public class EmailModel<T>
    {
        private string _from;

        private string _mailcc;

        private string _mailcco;

        private string _mailto;

        private string _replyto;
        public string formato { get; set; }

        public string mailto
        {
            get => _mailto;
            set => _mailto = value.Replace("{", "<").Replace("}", ">");
        }

        public string mailcc
        {
            get => _mailcc;
            set => _mailcc = value.Replace("{", "<").Replace("}", ">");
        }

        public string mailcco
        {
            get => _mailcco;
            set => _mailcco = value.Replace("{", "<").Replace("}", ">");
        }

        public string replyto
        {
            get => _replyto;
            set => _replyto = value.Replace("{", "<").Replace("}", ">");
        }

        public string from
        {
            get => _from;
            set => _from = value.Replace("{", "<").Replace("}", ">");
        }


        public string subject { get; set; }
        public string body { get; set; }

        public T objeto { get; set; }

        //criado para tipo genericos e para passa uma mensagem de erro ou alerta
        public string mensagens { get; set; }
    }
}