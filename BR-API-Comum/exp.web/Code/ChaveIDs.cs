using System;

namespace exp.web.Code
{
    public class ChaveIDs
    {
        public static string id()
        {
            string newid = null;
            var Temp = DateTime.Now.AddSeconds(1);
            // ou string Temp1 = (new Random().Next(111111, 999999)).ToString();
            var Temp1 = Convert.ToInt64((9999 - 1000 + 1) * new Random().NextDouble() + 1000).ToString();
            newid += Temp.ToString("yyMMddHHmmss");
            newid += Temp1;
            // Int n = 1;
            // Acresccentar zero a esquerta até completar a quantidade de caraccteres
            // string ns = n.ToString().PadLeft(6, '0');
            // writer.Write(String.Format("{0:################}", "121131346546464646464654646464646");

            return newid;
        }
    }
}