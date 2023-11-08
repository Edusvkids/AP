using HGAPI.DTOs.UserPlayerDTOs;
using HGAPI.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace HGAPI.Models.DAL
{
	public class AccountDAL
	{
		readonly HGAPIContext _dbContext;

		public AccountDAL(HGAPIContext hGAPIContext)
		{
			_dbContext = hGAPIContext;
		}

		public async Task<int> SignUp(UserPlayerEN userPlayer)
		{
			_dbContext.Add(userPlayer);
			return await _dbContext.SaveChangesAsync();
		}

		/// <summary>
		/// ///////////////////////////////////////////////
		/// </summary>
		/// <param name="pUser"></param>
		/// <returns></returns>
		public async Task<UserLoginOutputDTO> SignIn(UserLoginInputDTO pUser)
		{
			var userEn = await _dbContext.userPlayerEN.FirstOrDefaultAsync(s => s.PasswordPlayer == pUser.Password && s.NamePlayer == pUser.UserName);
			if (userEn != null)
			{
				var userAuth = new UserLoginOutputDTO
				{
					Id = userEn.Id,
					UserName = userEn.NamePlayer,
					Email = userEn.GmailPlayer
				};
				return userAuth;
			}
			else
				return new UserLoginOutputDTO();
		}
		/// ///////////////////////////////////////////////
		/// ///////////////////////////////////////////////
	}
}
