using MediatR;

namespace ESCMB.API.Controllers
{
    internal class DeleteCustomerCommand : IRequest<object>
    {
        public int Id { get; set; }
    }
}