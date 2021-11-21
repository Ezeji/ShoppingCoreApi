using ShoppingCoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCoreRepository.Interfaces
{
    public interface IDiscountStoreRepository
    {
        Task<DiscountStore> GetItemDetailsFromStore(string sku);

        Task<List<DiscountStore>> GetItemsFromStore();
    }
}
