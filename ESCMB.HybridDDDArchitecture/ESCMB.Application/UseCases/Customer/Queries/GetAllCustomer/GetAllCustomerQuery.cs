using Core.Application.ComandQueryBus.Queries;
using ESCMB.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Customer.Queries.GetAllCustomer
{
    public class GetAllCustomerQuery : QueryRequest<QueryResult<CustomerDto>>
    {
    }
}
