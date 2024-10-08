﻿namespace Core.Application.ComandQueryBus.Queries
{
    public class QueryRequest<TResponse> : IRequestQuery<TResponse>
        where TResponse : class
    {
        public uint PageIndex { get; set; }
        public uint PageSize { get; set; }
    }
}
