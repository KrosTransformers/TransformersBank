using System.Data.Entity;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Respositories
{
    public class TransactionRepository : BaseRepository<Transaction, long>
    {
        public TransactionRepository(DbSet<Transaction> dbSet, DbContext dbContext) : base(dbSet, dbContext)
        {
        }
    }
}
