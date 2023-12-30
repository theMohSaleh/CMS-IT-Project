using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMSWebpage.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CMSWebpage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public OrdersController(ProjectDBContext context)
        {
            _context = context;
        }

        public class orderPlace
        {
            public string userId { get; set; }
            public string didCheck { get; set; }
        }

        [HttpPost("place")]
        public async Task<ActionResult<Order>> PostOrder(orderPlace id)
        {
            try
            {
                int userId = int.Parse(id.userId);
                int isChecked;

                if (int.Parse(id.didCheck) == 1)
                {
                    isChecked = 1;
                } else
                {
                    isChecked = 0;
                }

                double roundedSum = Math.Round(
                    _context.OrderCarts
                        .Where(x => x.UserId == userId)
                        .Sum(x => x.Item.Price * x.Quantity),
                         3,
                         MidpointRounding.AwayFromZero
                         );

                // create order object
                Order newOrder = new Order()
                {
                    UserId = userId,
                    IsPaid = 0,
                    TotalAmount = roundedSum,
                    TableNumber = 0,
                    IsOccupied = (byte?)isChecked
                };


                // add order object to database
                _context.Orders.Add(newOrder);

                await _context.SaveChangesAsync();

                OrderItem orderItem;

                var userOrder = await _context.OrderCarts.Where(x => x.UserId == userId).ToListAsync();

                // get all items
                foreach (OrderCart userItem in userOrder)
                {
                    Item item = _context.Items.Where(x => x.ItemId == userItem.ItemId).FirstOrDefault()!;

                    orderItem = new OrderItem()
                    {
                        OrderId = newOrder.OrderId,
                        ItemId = item.ItemId,
                        Quantity = userItem.Quantity,
                        Subtotal = Math.Round(item.Price * userItem.Quantity, 3, MidpointRounding.AwayFromZero)
                    };
                    Console.WriteLine("Current order item: "+orderItem);
                    _context.OrderItems.Add(orderItem);
                }

                await _context.SaveChangesAsync();

                var removeUserOrder = await _context.OrderCarts.Where(x => x.UserId == userId).ToListAsync();

                foreach (OrderCart userItem in removeUserOrder)
                {
                    Console.WriteLine("Current item delete: " + userItem);
                    _context.OrderCarts.Remove(userItem);

                }
                await _context.SaveChangesAsync();

                return Ok(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ProjectDBContext.Orders'  is null.");
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
