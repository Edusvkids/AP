using HGAPI.Auth;
using HGAPI.DTOs.UserPlayerDTOs;
using HGAPI.Models.DAL;
using HGAPI.Models.EN;

namespace HGAPI.Endpoints
{
	public static class AcountEndPoint
	{
		public static void AccountEndpoints(this WebApplication app)
		{
			app.MapPost("/account/signup", async (CreateUserPlayerDTO userPlayerDTO, AccountDAL accountDAL) =>
			{
				var userPlayer = new UserPlayerEN
				{
					NamePlayer = userPlayerDTO.NamePlayer,
					GmailPlayer = userPlayerDTO.GmailPlayer,
					PasswordPlayer = userPlayerDTO.PasswordPlayer
				};
				int result = await accountDAL.SignUp(userPlayer);
				if (result != 0)
					return Results.Ok(result);
				else
					return Results.StatusCode(500);
			});

			app.MapPost("/account/signin", async (UserLoginInputDTO userLoginInput, AccountDAL accountDAL, IJwtAuthenticationService jwt) =>
			{
				UserLoginOutputDTO auth = await accountDAL.SignIn(userLoginInput);

				if (auth.Id > 0)
				{
					string token = jwt.Authenticate(auth.UserName);
					auth.Token = token;
					return Results.Ok(auth);
				}
				else
				{
					return Results.Unauthorized();
				}
			});
		}
	}
}
