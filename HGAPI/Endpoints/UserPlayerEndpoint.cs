using HGAPI.Models.DAL;
using HGAPI.Models.EN;
using HGAPI.DTOs.UserPlayerDTOs;
using HGAPI.Auth;

namespace HGAPI.Endpoints
{
    public static class UserPlayerEndpoint
    {
        public static void AddUserPlayerEndpoints(this WebApplication app)
        {
            app.MapPost("/userplayer/search", async (SearchQueryUserPlayerDTO userPlayerDTO, UserPlayerDAL userPlayerDAL) =>
            {
                var userPlayer = new UserPlayerEN
                {
                    NamePlayer = userPlayerDTO.NamePlayer_Like != null ? userPlayerDTO.NamePlayer_Like : string.Empty,
                    GmailPlayer = userPlayerDTO.GmailPlayer_Like != null ? userPlayerDTO.GmailPlayer_Like : string.Empty
                };
                var userPlayers = new List<UserPlayerEN>();
                int countRow = 0;

                if (userPlayerDTO.SendRowCount == 2)
                {
                    userPlayers = await userPlayerDAL.Search(userPlayer, skip: userPlayerDTO.Skip, take: userPlayerDTO.Take);
                    if (userPlayers.Count > 0)
                        countRow = await userPlayerDAL.CountSearch(userPlayer);
                }
                else
                {
                    userPlayers = await userPlayerDAL.Search(userPlayer, skip: userPlayerDTO.Skip, take: userPlayerDTO.Take);
                }
                var userPlayerResult = new SearchResultUserPlayerçDTO
                {
                    Data = new List<SearchResultUserPlayerçDTO.UserPlayerDTO>(),
                    CoutRow = countRow
                };

                userPlayers.ForEach(h =>
                {
                    userPlayerResult.Data.Add(new SearchResultUserPlayerçDTO.UserPlayerDTO
                    {
                        Id = h.Id,
                        NamePlayer = h.NamePlayer,
                        GmailPlayer = h.GmailPlayer,
                        PasswordPlayer = h.PasswordPlayer
                    });
                });
                return userPlayerResult;
            });
            app.MapGet("/userplayer/{id}", async (int id, UserPlayerDAL userPlayerDAL) =>
            {
                var userPlayer = await userPlayerDAL.GetById(id);

                var userPlayerResult = new GetIdResultUserPlayerDTO
                {
                    Id = userPlayer.Id,
                    NamePlayer = userPlayer.NamePlayer,
                    GmailPlayer = userPlayer.GmailPlayer,
                    PasswordPlayer = userPlayer.PasswordPlayer
                };
                if (userPlayerResult.Id > 0)
                    return Results.Ok(userPlayerResult);
                else
                    return Results.NotFound(userPlayerResult);
            });

            app.MapPut("/userplayer", async (EditUserPlayerDTO userPlayerDTO, UserPlayerDAL userPlayerDAL) =>
            {
                var userPlayer = new UserPlayerEN
                {
                    Id = userPlayerDTO.Id,
                    NamePlayer = userPlayerDTO.NamePlayer,
                    GmailPlayer = userPlayerDTO.GmailPlayer,
                    PasswordPlayer = userPlayerDTO.PasswordPlayer
                };
                int result = await userPlayerDAL.Edit(userPlayer);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
            app.MapDelete("/userplayer/{id}", async (int id, UserPlayerDAL userPlayerDAL) =>
            {
                int result = await userPlayerDAL.Delete(id);
                if (result != 0)
                    return Results.Ok(result);
                else return Results.StatusCode(500);
            });
        }
    }
}
