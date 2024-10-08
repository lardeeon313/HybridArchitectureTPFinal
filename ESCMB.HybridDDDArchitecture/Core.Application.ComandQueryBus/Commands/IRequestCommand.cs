using MediatR;

namespace Core.Application.ComandQueryBus.Commands
{
    public interface IRequestCommand : IRequest
    {
    }

    public interface IRequestCommand<out TResponse> : IRequest<TResponse>
    {
    }
}
