using HGAPI.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace HGAPI.Models.DAL
{
    public class PuchaseOrderDAL
    {
        readonly HGAPIContext _context;

        public PuchaseOrderDAL(HGAPIContext context)
        {
            _context = context;
        }

        public async Task<int> Create(PurchaseOrder purchaseOrder)
        {
            purchaseOrder.StateOrder = "Pay";
            _context.Add(purchaseOrder);
            return await _context.SaveChangesAsync();
        }

        public async Task<PurchaseOrder> GetById(int id)
        {
            var purchaseOrder = await _context.purchaseOrder.FirstOrDefaultAsync(x => x.Id == id);
            return purchaseOrder != null ? purchaseOrder : new PurchaseOrder();
        }
        public async Task<List<PurchaseOrder>> GetOrderByUser(int id)
        {
            var purchaseOrders = await _context.purchaseOrder.Where(x => x.IdUserPlayer == id && x.StateOrder=="Pay").ToListAsync();
            return purchaseOrders != null ? purchaseOrders : new List<PurchaseOrder>();
        }
        public async Task<int> UpdateOrderByUser(int id)
        {
            int result = 0;
            var purchaseOrders = await _context.purchaseOrder.Where(x => x.IdUserPlayer == id && x.StateOrder == "Pay").ToListAsync();
            foreach (var item in purchaseOrders) {
                item.StateOrder = "Done";
            }           
             result = await _context.SaveChangesAsync();            
            return result;
        }
        public async Task<int> Edit(PurchaseOrder purchaseOrder)
        {
            int result = 0;
            var purchaseOrderUpdate = await GetById(purchaseOrder.Id);
            if (purchaseOrderUpdate.Id != 0)
            {
                purchaseOrderUpdate.NameOrder = purchaseOrder.NameOrder;
                purchaseOrderUpdate.DateOrder = purchaseOrder.DateOrder;
                purchaseOrderUpdate.Headline = purchaseOrder.Headline;
                purchaseOrderUpdate.StateOrder = purchaseOrder.StateOrder;
                purchaseOrderUpdate.Total = purchaseOrder.Total;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            var purchaseOrderDelete = await GetById(id);
            if (purchaseOrderDelete.Id > 0)
            {
                _context.purchaseOrder.Remove(purchaseOrderDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        private IQueryable<PurchaseOrder> Query(PurchaseOrder purchaseOrder)
        {
            var query = _context.purchaseOrder.AsQueryable();
            if (!string.IsNullOrWhiteSpace(purchaseOrder.NameOrder))
                query = query.Where(s => s.NameOrder.Contains(purchaseOrder.NameOrder));
            if (!string.IsNullOrWhiteSpace(purchaseOrder.Headline))
                query = query.Where(s => s.Headline.Contains(purchaseOrder.Headline));
            return query;
        }

        public async Task<List<PurchaseOrder>> Search(PurchaseOrder purchaseOrder, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(purchaseOrder);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }

        public async Task<int> CountSearch(PurchaseOrder purchaseOrder)
        {
            return await Query(purchaseOrder).CountAsync();
        }
    }
}
