using System.Data.Entity;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Respositories
{
    public class CustomerRepository : BaseRepository<Customer, long>
    {
        public CustomerRepository(DbSet<Customer> dbSet, DbContext dbContext) : base(dbSet, dbContext)
        {
        }
    }
}
