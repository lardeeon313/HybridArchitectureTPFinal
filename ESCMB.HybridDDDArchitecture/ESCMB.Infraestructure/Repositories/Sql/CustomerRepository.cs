using Core.Application.Repositories;
using Core.Infraestructure.Repositories.Sql;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Infraestructure.Repositories.Sql
{
    internal sealed class CustomerRepository(StoreDbContext context) : BaseRepository<Customer>(context), ICustomerRepository
    {

        public string AddOneAsync(Customer entity)
        {
            context.Customer.Add(entity);
            return entity.Id.ToString();
        }

        public Customer FindOne(params object[] keyValues)
        {
            return context.Customer.Find(keyValues);
        }

        public ValueTask<Customer> FindOneAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        Task<int> ISqlRepository<Customer>.AddAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        Task<int> ISqlRepository<Customer>.CountAsync(Expression<Func<Customer, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
