using Microsoft.EntityFrameworkCore;
using HGAPI.Models.EN;

namespace HGAPI.Models.DAL
{
    public class HGAPIContext : DbContext
    {
        public HGAPIContext(DbContextOptions<HGAPIContext>options) : base(options)
        {

        }
        public DbSet<UserPlayerEN> userPlayerEN { get; set; }
    }
}
