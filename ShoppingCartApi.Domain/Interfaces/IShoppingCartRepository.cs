using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApi.Domain.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<IEnumerable<CartItem>> GetAll();
        Task<CartItem?> GetById(int id);
        Task Add(CartItem cartItem);
        Task Update(CartItem cartItem);
        Task Delete(int id);
    }
}
