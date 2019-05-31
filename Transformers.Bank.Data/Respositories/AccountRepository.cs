using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transformers.Bank.Entities;

namespace Transformers.Bank.Data.Respositories
{
    public class AccountRepository : BaseRepository<Account, long>
    {
        public AccountRepository(DbSet<Account> dbSet) : base(dbSet)
        {
        }
    }
}
