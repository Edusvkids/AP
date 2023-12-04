using Microsoft.EntityFrameworkCore;
using HGAPI.Models.EN;
using HGAPI.Interface;
using HGAPI.DTOs.ProductGamesDTOs;

namespace Crypto.ArqLimpia.DAL
{
    public class ProductGamesDAL : IProduct
    {
        readonly CryptoDbContext dbContext;

        public ProductGamesDAL(CryptoDbContext pdbContext)
        {
            dbContext = pdbContext;
        }

        public void Create(ProductGames pProducts)
        {
            dbContext.Cryptocurrencies.Add(pProducts);
        }

        public void Delete(ProductGames pProducts)
        {
            dbContext.Cryptocurrencies.Remove(pProducts);
        }

        public async Task<ProductGames> GetById(ProductGames pProducts)
        {
            ProductGames? product = await dbContext.Cryptocurrencies.FirstOrDefaultAsync(s => s.Id == pProducts.Id);
            if (product != null)
                return product;
            else
                return new ProductGames();
        }


        public void Update(ProductGames pProducts)
        {
            dbContext.Cryptocurrencies.Update(pProducts);
        }

        public async Task<List<ProductGames>> Search(getProductsInputDTOs pProducts)
        {
            IQueryable<ProductGames> query = dbContext.Cryptocurrencies.AsQueryable();

            // Filtrar por Nombre
            if (!string.IsNullOrEmpty(pProducts.Moneda))
            {
                query = query.Where(p => p.Moneda.Contains(pProducts.Moneda));
            }


            return await query.ToListAsync();
        }

        public async Task<ProductGames> GetById(int id)
        {
            ProductGames product = await dbContext.Cryptocurrencies.FindAsync(id);
            return product;
        }
    }
}