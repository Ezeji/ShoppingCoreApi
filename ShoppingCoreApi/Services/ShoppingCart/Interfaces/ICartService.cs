using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCoreApi.Services.ShoppingCart.Interfaces
{
    public interface ICartService
    {
        Task<ServiceResponse<string>> CreateCartItems(List<string> itemNames);

        Task<ServiceResponse<string>> DeleteCartItems(string shoppingCode);

        Task<ServiceResponse<string>> GetItemsTotalAmount(string shoppingCode);
    }
}
