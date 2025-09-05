using System.Collections.Generic;

namespace exp.core.Utilitarios
{
    public class HttpResposta<T>
    {
        public T objeto { get; set; }
        public Dictionary<string, string[]> erros { get; set; }
    }
//new Resposta<cliente>();
}