using Crypto.ArqLimpia.DAL;

namespace HGAPI.Models.DAL
{
    public interface IUnitOfWork
    {
        public class UnitOfWork : IUnitOfWork
        {
            readonly CryptoDbContext dbContext;

            public UnitOfWork(CryptoDbContext pDbContext)
            {
                dbContext = pDbContext;
            }
            public Task<int> SaveChangesAsync()
            {
                return dbContext.SaveChangesAsync();

            }
        }
    }
}