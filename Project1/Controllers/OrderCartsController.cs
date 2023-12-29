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
    [Route("api/[controller]")]
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

        // GET: api/OrderCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderCart>> GetOrderCart(int id)
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
