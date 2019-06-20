using System.Data.Entity;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Respositories
{
    public class AccountRepository : BaseRepository<Account, long>
    {
        public AccountRepository(DbSet<Account> dbSet, DbContext dbContext) : base(dbSet, dbContext)
        {
        }
    }
}
