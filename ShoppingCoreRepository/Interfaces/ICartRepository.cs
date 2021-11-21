using ShoppingCoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCoreRepository.Interfaces
{
    public interface ICartRepository
    {
        Task<string> AddItems(Cart cart);

        Task<string> RemoveItems(Cart cart);

        Task<List<Cart>> GetItems(string shoppingCode);
    }
}
