using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infraestructure.Repositories.MongoDb
{
    public abstract class DbContext
    {
        protected IMongoDatabase Database;

        public abstract IMongoCollection<TEntity> GetCollection<TEntity>();

        protected DbContext(string connectionString)
        {

            MongoUrl url = new(connectionString ?? throw new ArgumentNullException(nameof(connectionString)));
            MongoClient client = new(url);
            Database = client.GetDatabase(url.DatabaseName);
        }
    }
}
