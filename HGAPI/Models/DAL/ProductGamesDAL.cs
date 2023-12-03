using HGAPI.Models.EN;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace HGAPI.Models.DAL
{
    public class ProductGamesDAL
    {
        readonly HGAPIContext _context;

        public ProductGamesDAL(HGAPIContext context)
        {
            _context = context;
        }

        public async Task<int> Create(ProductGames productGames)
        {
            _context.Add(productGames);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductGames> GetById(int id)
        {
            var productGames = await _context.productGames.FirstOrDefaultAsync(s => s.Id == id);
            return productGames != null ? productGames : new ProductGames();
        }

        public async Task<int> Edit(ProductGames productGames)
        {
            int result = 0;
            var productGamesUpdate = await GetById(productGames.Id);
            if (productGamesUpdate.Id != 0)
            {
                productGamesUpdate.NameProduct = productGamesUpdate.NameProduct;
                productGamesUpdate.DescriptionProduct = productGamesUpdate.DescriptionProduct;
                productGamesUpdate.PriceProduct = productGamesUpdate.PriceProduct;
                productGamesUpdate.TypeProduct = productGamesUpdate.TypeProduct;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            var productGamesDelete = await GetById(id);
            if (productGamesDelete.Id > 0)
            {
                _context.productGames.Remove(productGamesDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        private IQueryable<ProductGames> Query(ProductGames productGames)
        {
            var query = _context.productGames.AsQueryable();
            if (!string.IsNullOrWhiteSpace(productGames.NameProduct))
                query = query.Where(s => s.NameProduct.Contains(productGames.NameProduct));
            if (!string.IsNullOrWhiteSpace(productGames.DescriptionProduct))
                query = query.Where(s => s.DescriptionProduct.Contains(productGames.DescriptionProduct));
            return query;
        }

        public async Task<int> CountSearch(ProductGames productGames)
        {
            return await Query(productGames).CountAsync();
        }

        public async Task<List<ProductGames>> Search(ProductGames productGames, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(productGames);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
