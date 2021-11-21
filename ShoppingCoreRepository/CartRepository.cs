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
    public class CartRepository : ICartRepository
    {
        private readonly ShoppingDBContext _context;

        public CartRepository(ShoppingDBContext context)
        {
            _context = context;
        }

        public async Task<string> AddItems(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            return "Item(s) created";
        }

        public async Task<string> RemoveItems(Cart cart)
        {
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return "Item(s) deleted";
        }

        public async Task<List<Cart>> GetItems(string shoppingCode)
        {
            List<Cart> cartItems = await _context.Carts.Where(cart => cart.ShoppingCode.ToLower() == shoppingCode.ToLower())
                                                       .AsNoTracking()
                                                       .ToListAsync();

            return cartItems;
        }

    }
}
