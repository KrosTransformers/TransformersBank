using System.Data.Entity;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Respositories
{
    public class BranchRepository : BaseRepository<Branch, long>
    {
        public BranchRepository(DbSet<Branch> dbSet, DbContext dbContext) : base(dbSet, dbContext)
        {
        }
    }
}
