namespace exp.core
{
    /// <summary>
    ///     Paged list interface
    /// </summary>
    public interface IPagedList
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        int PreviousPage { get; }
        int NextPage { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        bool HasPages { get; }
    }
}