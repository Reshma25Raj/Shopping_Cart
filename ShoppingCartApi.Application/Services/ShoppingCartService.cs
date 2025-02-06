using ShoppingCartApi.Domain;
using ShoppingCartApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApi.Application.Services
{
    public class ShoppingCartService
    {
        private readonly IShoppingCartRepository _repository;

        public ShoppingCartService(IShoppingCartRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CartItem>> GetAllItems()
        {
            return await _repository.GetAll();
        }

        public async Task<CartItem?> GetItemById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task AddItem(CartItem cartItem)
        {
            await _repository.Add(cartItem);
        }

        public async Task UpdateItem(CartItem cartItem)
        {
            await _repository.Update(cartItem);
        }

        public async Task DeleteItem(int id)
        {
           await  _repository.Delete(id);
        }
    }
}
