using MediatR;

namespace Core.Application.ComandQueryBus.Queries
{
    public interface IRequestQueryHandler<in TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest
    {
    }

    public interface IRequestQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
    }
}
