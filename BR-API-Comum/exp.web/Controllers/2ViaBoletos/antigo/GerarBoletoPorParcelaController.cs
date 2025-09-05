using System.Web.Http;
using exp.web.Code;

namespace exp.web.Controllers.API
{
    //NAÔ ESTÁ SENDO MASI UTILIZADO 
    //FOI SUBSTITUIDO PELA API NOVA DA EXPERTU
    //ESTA SENDO CHAMADA DIRETAMENTE DOS SITES
    public class GerarBoletoPorParcelaController : ApiController
    {
        //int site = UserWebApiHelper.Id;
        //string Nome = UserWebApiHelper.Nome;
        //string Login = UserWebApiHelper.Login;
        //int Empresa = Convert.ToInt32(UserWebApiHelper.Empresa);

        //public string GetGerarBoletoPorParcela(string id, string parcela)
        //{

        //    bool resultado = AcessoWebService.BoletoPorParcela(id, parcela);

        //    if (resultado)
        //    {

        //        return resultado.ToString();

        //    }
        //    else {

        //        return string.Empty;
        //    }

        //}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}