using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMSWebpage.Model;

namespace CMSWebpage.Controllers
{
    [Route("api/orderCart")]
    [ApiController]
    public class OrderCartsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public OrderCartsController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/OrderCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderCart>>> GetOrderCarts()
        {
          if (_context.OrderCarts == null)
          {
              return NotFound();
          }
            return await _context.OrderCarts.ToListAsync();
        }

        public class CartRequest
        {
            public string userId { get; set; }
            public string ItemId { get; set; }
        }

        public class UpdateQuantity
        {
            public string userId { get; set; }
            public string itemId { get; set; }
            public string increase { get; set; }
        }

        [HttpPost("adjust")]
        public async Task<IActionResult> AddToCart([FromBody] UpdateQuantity updateCart)
        {
            try
            {
                int userId = int.Parse(updateCart.userId);
                int itemId = int.Parse(updateCart.itemId);
                int increase = int.Parse(updateCart.increase);

                OrderCart orderItem = await _context.OrderCarts
                    .Where(x => x.UserId == userId && x.ItemId == itemId)
                    .FirstOrDefaultAsync();

                if (increase == 1)
                {
                    orderItem.Quantity++;
                    _context.OrderCarts.Update(orderItem);
                    await _context.SaveChangesAsync();
                }
                else if (increase == 0)
                {
                    orderItem.Quantity--;
                    if (orderItem.Quantity == 0)
                    {
                        _context.OrderCarts.Remove(orderItem);
                        await _context.SaveChangesAsync();
                    }
                }
                // return success
                return Ok(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPost("cart")]
        public async Task<IActionResult> AddToCart([FromBody] CartRequest newCart)
        {
            try
            {
                OrderCart orderItem = await _context.OrderCarts
                    .Where(x => x.UserId == int.Parse(newCart.userId) && x.ItemId == int.Parse(newCart.ItemId))
                    .FirstOrDefaultAsync();

                // check if item already exists in the cart
                if (orderItem != null)
                {
                    // update save
                    orderItem.Quantity += 1;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // add new item to cart if it was not added previously
                    OrderCart newOrderItem = new OrderCart
                    {
                        UserId = int.Parse(newCart.userId),
                        ItemId = int.Parse(newCart.ItemId),
                        Quantity = 1
                    };
                    // save
                    _context.OrderCarts.Add(newOrderItem);
                    await _context.SaveChangesAsync();
                }

                // return success
                return Ok(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        // GET: api/OrderCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderCart>>> GetOrderCart(int id)
        {
          if (_context.OrderCarts == null)
          {
              return NotFound();
          }
            var orderCart = await _context.OrderCarts.Where(
                x => x.UserId == id
                ).ToListAsync();

            if (orderCart == null)
            {
                return NotFound();
            }

            return orderCart;
        }

        // PUT: api/OrderCarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderCart(int id, OrderCart orderCart)
        {
            if (id != orderCart.OrderCartID)
            {
                return BadRequest();
            }

            _context.Entry(orderCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderCartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderCarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderCart>> PostOrderCart(OrderCart orderCart)
        {
          if (_context.OrderCarts == null)
          {
              return Problem("Entity set 'ProjectDBContext.OrderCarts'  is null.");
          }
            _context.OrderCarts.Add(orderCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderCart", new { id = orderCart.OrderCartID }, orderCart);
        }

        // DELETE: api/OrderCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderCart(int id)
        {
            if (_context.OrderCarts == null)
            {
                return NotFound();
            }
            var orderCart = await _context.OrderCarts.FindAsync(id);
            if (orderCart == null)
            {
                return NotFound();
            }

            _context.OrderCarts.Remove(orderCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderCartExists(int id)
        {
            return (_context.OrderCarts?.Any(e => e.OrderCartID == id)).GetValueOrDefault();
        }
    }
}
