using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.ApplicationServices.Customer
{
    public interface ICustomerApplicationService
    {
        bool CustomerExist(object value);

    }
}
