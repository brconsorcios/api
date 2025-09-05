
using System.Collections.Generic;


namespace BrConsorcio.Api.Models
{
    public class PaginacaoApi<T>
    {
    //    public PaginacaoApi();

        public List<T> objeto { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int PreviousPage { get; }
        public int NextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPages { get; set; }
    }
}
