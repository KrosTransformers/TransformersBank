using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers.Bank.Data.Context
{
    public interface IDbContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
