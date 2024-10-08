using MediatR;

namespace Core.Application.ComandQueryBus.Queries
{
    public interface IRequestQuery : IRequest
    {
    }

    public interface IRequestQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
