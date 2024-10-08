using Core.Application.ComandQueryBus.Queries;
using Core.Application.Mapping;
using ESCMB.Application.DataTransferObjects;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Application.UseCases.DummyEntity.Queries.GetAllDummyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Customer.Queries.GetAllCustomer
{
    public class GetAllCustomerHandler(ICustomerRepository context) : IRequestQueryHandler<GetAllCustomerQuery, QueryResult<CustomerDto>>
    {
        private readonly ICustomerRepository _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<QueryResult<CustomerDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            IList<Domain.Entities.Customer> entities = await _context.FindAllAsync();

            return new QueryResult<CustomerDto>(entities.To<CustomerDto>(), entities.Count, request.PageIndex, request.PageSize);
        }
    }
}
