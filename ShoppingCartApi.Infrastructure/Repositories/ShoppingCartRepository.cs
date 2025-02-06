using ShoppingCartApi.Domain;
using ShoppingCartApi.Domain.Interfaces;
using ShoppingCartApi.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApi.Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShoppingCartDbContext _context;

        public ShoppingCartRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItem>> GetAll()
        {
           return  _context.CartItems.ToList();
        }

        public async Task<CartItem?> GetById(int id)
        {
            return await _context.CartItems.FindAsync(id);
        }

        public async Task Add(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task Update(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
        }
        
        public async Task Delete(int id)
        {
            var item = _context.CartItems.Find(id);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}