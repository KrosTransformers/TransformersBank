using System.Data.Entity;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Respositories
{
    public class AddressRepository : BaseRepository<Address, long>
    {
        public AddressRepository(DbSet<Address> dbSet, DbContext dbContext) : base(dbSet, dbContext)
        {
        }
    }
}
