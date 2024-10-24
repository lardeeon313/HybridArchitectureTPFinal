using ESCMB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Infraestructure.Repositories.Sql;
using ESCMB.Application.Repositories.Sql;
namespace ESCMB.Infraestructure.Repositories.Sql
{
    internal sealed class AccountRepository(StoreDbContext context) : BaseRepository<Account>(context), IAccountRepository
    {
    }
}
