using ESCMB.Application.Repositories.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.ApplicationServices.Customer
{
    public class CustomerApplicationService(ICustomerRepository context) : ICustomerApplicationService
    {
        private readonly ICustomerRepository _context = context ?? throw new ArgumentNullException(nameof(context));
        public bool CustomerExist(object value)
        {
            value = value ?? throw new ArgumentNullException(nameof(value));

            var response = _context.FindOne(value);

            return response != null;
        }
    }
}
