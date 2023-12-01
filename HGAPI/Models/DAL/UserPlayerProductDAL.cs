using HGAPI.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace HGAPI.Models.DAL
{
    public class UserPlayerProductDAL
    {
        readonly HGAPIContext _context;

        public UserPlayerProductDAL(HGAPIContext hGAPIContext)
        {
            _context = hGAPIContext;
        }

        public async Task<int> Create(UserPlayerProductEN userPlayerProductEN)
        {
            _context.Add(userPlayerProductEN);
            return await _context.SaveChangesAsync();
        }

        public async Task<UserPlayerProductEN> GetById(int Id)
        {
            var userplayerproducen = await _context.UserPlayerProduct.FirstOrDefaultAsync(x => x.Id == Id);
            return userplayerproducen != null ? userplayerproducen : new UserPlayerProductEN();
        }

        public async  Task<int> Edit(UserPlayerProductEN userPlayerProductEN)
        {
            int result = 0;
            var userPlayerProductENUpdate = await GetById(userPlayerProductEN.Id);
            if (userPlayerProductENUpdate.Id != 0)
            {
                userPlayerProductENUpdate.PruductStatus = userPlayerProductEN.PruductStatus;
                userPlayerProductENUpdate.NamePlayer = userPlayerProductEN.NamePlayer;
                userPlayerProductENUpdate.GmailPlayer = userPlayerProductEN.GmailPlayer;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var userPlayerProductENDelete = await GetById(id);
            if (userPlayerProductENDelete.Id > 0)
            {
                _context.UserPlayerProduct.Remove(userPlayerProductENDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        private IQueryable<UserPlayerProductEN> Query(UserPlayerProductEN userPlayerProductEN)
        {
            var query = _context.UserPlayerProduct.AsQueryable();
            if (!string.IsNullOrWhiteSpace(userPlayerProductEN.NamePlayer))
                query = query.Where(s => s.NamePlayer.Contains(userPlayerProductEN.NamePlayer));
            if (!string.IsNullOrWhiteSpace(userPlayerProductEN.GmailPlayer))
                query = query.Where(s => s.GmailPlayer.Contains(userPlayerProductEN.GmailPlayer));
            if (!string.IsNullOrWhiteSpace(userPlayerProductEN.PruductStatus))
                query = query.Where(s => s.PruductStatus.Contains(userPlayerProductEN.PruductStatus));
            return query;
        }

        public async Task<int> CountSearch(UserPlayerProductEN userPlayerProductEN)
        {
            return await Query(userPlayerProductEN).CountAsync();
        }
        
        public async Task<List<UserPlayerProductEN>> Searc(UserPlayerProductEN userPlayerProductEN, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(userPlayerProductEN);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
