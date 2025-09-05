namespace exp.dados
{
    public class NewsletterModel
    {
        public NewsletterModel()
        {
            remover = false;
        }

        public string email { get; set; }
        public string link { get; set; }
        public bool? remover { get; set; }
    }
}