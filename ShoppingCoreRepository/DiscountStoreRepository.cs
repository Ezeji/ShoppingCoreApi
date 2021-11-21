using Microsoft.EntityFrameworkCore;
using ShoppingCoreData;
using ShoppingCoreData.Models;
using ShoppingCoreRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCoreRepository
{
    public class DiscountStoreRepository : IDiscountStoreRepository
    {
        private readonly ShoppingDBContext _context;

        public DiscountStoreRepository(ShoppingDBContext context)
        {
            _context = context;
        }

        public async Task<DiscountStore> GetItemDetailsFromStore(string sku)
        {
            DiscountStore discountStore = await _context.DiscountStores.Where(store => store.Sku.ToLower() == sku.ToLower())
                                                       .AsNoTracking()
                                                       .FirstOrDefaultAsync();

            return discountStore;
        }

        public async Task<List<DiscountStore>> GetItemsFromStore()
        {
            List<DiscountStore> discountStore = await _context.DiscountStores.AsNoTracking()
                                                       .ToListAsync();

            return discountStore;
        }

    }
}
