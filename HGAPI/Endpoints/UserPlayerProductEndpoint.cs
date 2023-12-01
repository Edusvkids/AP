using HGAPI.Models.DAL;
using HGAPI.Models.EN;
using HGAPI.DTOs.UserPlayerProductDTOs;

namespace HGAPI.Endpoints
{
    public static class UserPlayerProductEndpoint
    {
        public static void AddUserPlayerProductEndpoint(this WebApplication app)
        {
            app.MapPost("/ProductPlayer/search", async (SearchQueryUserPlayerProductDTO userplayerDTO, UserPlayerProductDAL userplayerDAL) =>
            {
                var userPlayerProduct = new UserPlayerProductEN
                {
                    NamePlayer = userplayerDTO.NamePlayer__Like != null ? userplayerDTO.NamePlayer__Like : string.Empty,
                    GmailPlayer = userplayerDTO.GmailPlayer__Like != null ? userplayerDTO.GmailPlayer__Like : string.Empty
                };

                var userplayers = new List<UserPlayerProductEN>();
                int conuntRow = 0;

                if (userplayerDTO.SeadRowCount == 2)
                {
                    userplayers = await userplayerDAL.Searc(userPlayerProduct, skip: userplayerDTO.skipe, take: userplayerDTO.take);
                    if (userplayers.Count > 0)
                        conuntRow = await userplayerDAL.CountSearch(userPlayerProduct);
                }
                else
                {
                    userplayers = await userplayerDAL.Searc(userPlayerProduct, skip:userplayerDTO.skipe,take: userplayerDTO.take);
                }
                var userplayerResult = new SearchQueryUserPlayerProductDTO
                {

                };
                
            });
        }
    }
}
