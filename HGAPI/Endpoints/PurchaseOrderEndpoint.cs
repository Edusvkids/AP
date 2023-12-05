using HGAPI.Models.DAL;
using HGAPI.Models.EN;
using HGAPI.DTOs.PurchaseOrderDTOs;

namespace HGAPI.Endpoints
{
    public static class PurchaseOrderEndpoint
    {
        public static void AddPurchaseOrderEndpoint(this WebApplication app)
        {
            app.MapPost("/order/search", async (SearchQueryPurchaseOrderDTO purchaseOrderDTO, PuchaseOrderDAL purchaseOrderDAL) =>
            {
                var purchaseOrder = new PurchaseOrder
                {
                    NameOrder = purchaseOrderDTO.NameOrder__Like != null ? purchaseOrderDTO.NameOrder__Like : string.Empty,
                    Headline = purchaseOrderDTO.Headline__Like != null ? purchaseOrderDTO.Headline__Like : string.Empty,
                };

                var purchaseOrders = new  List<PurchaseOrder>();
                int countRow = 0;

                if (purchaseOrderDTO.SendRowCount == 2)
                {
                    purchaseOrders = await purchaseOrderDAL.Search(purchaseOrder, skip: purchaseOrderDTO.Skip, take: purchaseOrderDTO.Take);
                    if (purchaseOrders.Count > 0)
                    {
                        countRow = await purchaseOrderDAL.CountSearch(purchaseOrder);
                    }
                }
                else
                {
                    purchaseOrders = await purchaseOrderDAL.Search(purchaseOrder, skip:purchaseOrderDTO.Skip,take: purchaseOrderDTO.Take);
                }
                var purchaseOrderResult = new SearchResultPurchaseOrderDTO
                {
                    Data = new List<SearchResultPurchaseOrderDTO.PurchaseOrderDTO>(),
                    CountRow = countRow,
                };

                purchaseOrders.ForEach(s =>
                {
                    purchaseOrderResult.Data.Add(new SearchResultPurchaseOrderDTO.PurchaseOrderDTO
                    {
                        Id = s.Id,
                        IdUserPlayer = s.IdUserPlayer,
                        IdProductGames = s.IdProductGames,
                        NameOrder = s.NameOrder,
                        DateOrder = s.DateOrder,
                        Headline = s.Headline,
                        Total = s.Total,
                    });
                });

                return purchaseOrderResult;
            });

            app.MapPost("/order", async (CreatePurchaseOrderDTO purchaseOrderDTO, PuchaseOrderDAL purchaseOrderDAL) =>
            {
                var purchaseOrder = new PurchaseOrder
                {
                    IdUserPlayer = purchaseOrderDTO.IdUserPlayer,
                    IdProductGames = purchaseOrderDTO.IdProductGames,
                    NameOrder = purchaseOrderDTO.NameOrder,
                    DateOrder = purchaseOrderDTO.DateOrder,
                    Headline = purchaseOrderDTO.Headline,
                    StateOrder = "Pendig",
                    Total = purchaseOrderDTO.Total,
                };
                int result = await purchaseOrderDAL.Create(purchaseOrder);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            app.MapGet("/order/{idUser}/pay", async (int idUser, PuchaseOrderDAL purchaseOrderDAL) =>
            {                
                var result = await purchaseOrderDAL.GetOrderByUser(idUser);
                if (result != null && result.Count > 0)
                    return Results.Ok(result);
                else
                    return Results.NoContent();
            });
            app.MapGet("/order/{idUser}/done", async (int idUser, PuchaseOrderDAL purchaseOrderDAL) =>
            {
                var result = await purchaseOrderDAL.UpdateOrderByUser(idUser);              
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
        }
    }
}
