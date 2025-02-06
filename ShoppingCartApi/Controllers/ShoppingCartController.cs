using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Application.Services;
using ShoppingCartApi.Domain;

namespace ShoppingCartApi.Controllers
{
    public class ShoppingCartController : ControllerBase
    {
        
        private readonly ShoppingCartService _service;

        public ShoppingCartController(ShoppingCartService service)
        {
            _service = service;
        }


        [HttpGet("GetAllItems")]
        [ProducesResponseType(typeof(IEnumerable<CartItem>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllItems());
        }

        [HttpGet("GetItem")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetItemById(id);
            return item != null ? Ok(item) : NotFound();
        }

        [HttpPost("AddItem")]
        public async Task<IActionResult> Add(CartItem cartItem)
        {
            await _service.AddItem(cartItem);
            return CreatedAtAction(nameof(GetById), new { id = cartItem.Id }, cartItem);
        }

        [HttpPut("UpdateItem")]
        public async Task<IActionResult> Update(int id, CartItem cartItem)
        {
            if (id != cartItem.Id) return BadRequest();
            await _service.UpdateItem(cartItem);
            return NoContent();
        }

        [HttpDelete("DeleteItem")]
        public async Task<IActionResult> Delete(int id)
        {
           await _service.DeleteItem(id);
            return NoContent();
        }
    }
}