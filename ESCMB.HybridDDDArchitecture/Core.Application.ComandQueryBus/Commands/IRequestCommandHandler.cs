using MediatR;

namespace Core.Application.ComandQueryBus.Commands
{
    public interface IRequestCommandHandler<in TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest
    {
    }

    public interface IRequestCommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
    }
}
