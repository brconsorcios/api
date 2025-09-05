using System.Collections.Generic;

namespace exp.core
{
    public class PaginacaoApi<T>
    {
        public List<T> objeto { get; set; }


        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }


        public int PreviousPage => PageIndex - 1;

        public int NextPage => PageIndex + 1;

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex + 1 <= TotalPages;

        public bool HasPages => TotalPages > 1;
    }
}