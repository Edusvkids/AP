using HGAPI.DTOs.ProductGamesDTOs;
using HGAPI.Models.DAL;
using HGAPI.Models.EN;
namespace HGAPI.Endpoints
{
    public static class ProductGamesEndpoint
    {
        public static void AddProductGamesEndPoints(this WebApplication app)
        {
            app.MapPost("/product/Search", async (SearchQueryProductGamesDTO productGamesDTO, ProductGamesDAL productGamesDAL) =>
            {
                var productGames = new ProductGames
                {
                    NameProduct = productGamesDTO.NameProduct__like != null ? productGamesDTO.NameProduct__like : string.Empty,
                    DescriptionProduct = productGamesDTO.DescriptionProduct__like != null ? productGamesDTO.DescriptionProduct__like : string.Empty,
                };

                var productGamess = new List<ProductGames>();
                int countRow = 0;

                if (productGamesDTO.SeandRowCount == 2)
                {
                    productGamess = await productGamesDAL.Search(productGames, skip: productGamesDTO.Skipe, take: productGamesDTO.Take);
                    if (productGamess.Count > 0)
                        countRow = await productGamesDAL.CountSearch(productGames);

                }
                else
                    productGamess = await productGamesDAL.Search(productGames, skip: productGamesDTO.Skipe, take: productGamesDTO.Take);
                var productGamesResult = new SearchResultProductGamesDTO
                {
                    Data = new List<SearchResultProductGamesDTO.ProductGamesDTO>(),
                    CountRow = countRow
                };
                productGamess.ForEach(s =>
                {
                    productGamesResult.Data.Add(new SearchResultProductGamesDTO.ProductGamesDTO
                    {
                        Id = s.Id,
                        NameProduct = s.NameProduct,
                        DescriptionProduct = s.DescriptionProduct,
                        PriceProduct = s.PriceProduct,
                        TypeProduct = s.TypeProduct,
                    });
                });
                return productGamesResult;
            });
            app.MapGet("/product/{id}", async (int id, ProductGamesDAL productGamesDal) =>
            {
                var productGames = await productGamesDal.GetById(id);

                var productGamesResult = new GetIdResultProductGamesDTO
                {
                    Id = productGames.Id,
                    NameProduct = productGames.NameProduct,
                    DescriptionProduct = productGames.DescriptionProduct,
                    PriceProduct = productGames.PriceProduct,
                    TypeProduct = productGames.TypeProduct,
                };
                if (productGamesResult.Id > 0)
                    return Results.Ok(productGamesResult);
                else
                    return Results.NotFound(productGamesResult);
            });
            app.MapPost("/product", async (CreateProductGamesDTO prodructGamesDTO, ProductGamesDAL productGamesDAL) =>
            {
                var productGames = new ProductGames
                {
                    NameProduct = prodructGamesDTO.NameProduct,
                    DescriptionProduct = prodructGamesDTO.DescriptionProduct,
                    PriceProduct = prodructGamesDTO.PriceProduct,
                    TypeProduct = prodructGamesDTO.TypeProduct,
                };
                int result = await productGamesDAL.Create(productGames);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
            app.MapPut("/product", async (EditProductGamesDTO productGamesDTO, ProductGamesDAL productGamesDal) =>
            {
                var productGames = new ProductGames
                {
                    Id = productGamesDTO.Id,
                    NameProduct = productGamesDTO.NameProduct,
                    DescriptionProduct = productGamesDTO.DescriptionProduct,
                    PriceProduct = productGamesDTO.PriceProduct,
                    TypeProduct = productGamesDTO.TypeProduct,

                };
                int result = await productGamesDal.Edit(productGames);
                if (result != 0)
                    return Results.Ok();
                else
                    return Results.StatusCode(500);
            });
            app.MapDelete("/product/{id}", async (int id, ProductGamesDAL productDAL) =>
            {
                int result = await productDAL.Delete(id);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
        }
    }
}
