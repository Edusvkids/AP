using HGAPI.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace HGAPI.Models.DAL
{
	public class UserPlayerDAL
    {
        readonly HGAPIContext _dbContext;

        public UserPlayerDAL(HGAPIContext hGAPIContext)
        {
            _dbContext = hGAPIContext;
        }
        
        public async Task<UserPlayerEN> GetById(int id)
        {
            var userPlayer = await _dbContext.userPlayerEN.FirstOrDefaultAsync(h => h.Id == id);
            return userPlayer != null ? userPlayer : new UserPlayerEN();
        }
        public async Task<int> Edit(UserPlayerEN userPlayer)
        {
            int result = 0;
            var userPlaterUpdate = await GetById(userPlayer.Id);
            if (userPlaterUpdate.Id !=0)
            {
                userPlaterUpdate.NamePlayer = userPlayer.NamePlayer;
                userPlaterUpdate.GmailPlayer = userPlayer.GmailPlayer;
                userPlaterUpdate.PasswordPlayer = userPlayer.PasswordPlayer;
                userPlaterUpdate.LevelPlayer = userPlayer.LevelPlayer;
                result = await _dbContext.SaveChangesAsync();
            }
            return result;
        }
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var userPlayerDelete = await GetById(id);
            if (userPlayerDelete.Id >0)
            {
                _dbContext.userPlayerEN.Remove(userPlayerDelete); ;
                result = await _dbContext.SaveChangesAsync();
            }
            return result;
        }
        private IQueryable<UserPlayerEN> Query(UserPlayerEN userPlayer)
        {
            var query = _dbContext.userPlayerEN.AsQueryable();
            if (!string.IsNullOrWhiteSpace(userPlayer.NamePlayer))
                query = query.Where(h => h.NamePlayer.Contains(userPlayer.NamePlayer));
            if (!string.IsNullOrWhiteSpace(userPlayer.GmailPlayer))
                query = query.Where(h => h.GmailPlayer.Contains(userPlayer.GmailPlayer));
            return query;
        }
        public async Task<int> CountSearch(UserPlayerEN userPlayer)
        {
            return await Query(userPlayer).CountAsync();
        }
        public async Task<List<UserPlayerEN>> Search(UserPlayerEN userPlayer, int take = 10, int skip = 0)
        {
            take = take == 0? 10 : take;
            var query = Query(userPlayer);
            query = query.OrderByDescending(h => h.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
