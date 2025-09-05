using exp.dados;

namespace exp.web.Template.Models
{
    public class PropostaParceriaPdfModel
    {
        public tbparceiro Parceiro { get; set; }

        public SiteLayout Layout { get; set; }

        public string LogoPath { get; set; }
    }
}