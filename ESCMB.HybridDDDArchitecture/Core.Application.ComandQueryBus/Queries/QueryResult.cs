namespace Core.Application.ComandQueryBus.Queries
{
    public class QueryResult<TEntity>(IEnumerable<TEntity> items, long count, uint pageSize, uint pageIndex)
        where TEntity : class
    {
        public long Count { get; private set; } = count;
        public IEnumerable<TEntity> Items { get; private set; } = items;
        public uint PageIndex { get; private set; } = pageIndex;
        public uint PageSize { get; private set; } = pageSize;
    }
}
