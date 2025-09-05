using System.Collections.Generic;
using System.Linq;

namespace exp.core
{
    /// <summary>
    ///     Paged list
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public class PagedList<T> : List<T>, IPagedList
    {
        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            if (pageIndex == 0)
                pageIndex = 1;

            var total = source.Count();
            TotalCount = total;
            TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;
            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            if (pageIndex == 0)
                pageIndex = 1;

            TotalCount = source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalCount">Total count</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            if (pageIndex == 0)
                pageIndex = 1;

            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source);
        }

        public string OrderByColumn { get; private set; }

        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public int TotalPages { get; }

        public int PreviousPage => PageIndex - 1;

        public int NextPage => PageIndex + 1;

        public bool HasPreviousPage => PageIndex > 0;

        public bool HasNextPage => PageIndex + 1 < TotalPages;

        public bool HasPages => TotalPages > 1;
    }
}