using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMSWebpage.Model;
using static CMSWebpage.Controllers.UsersController;

namespace CMSWebpage.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public ItemsController(ProjectDBContext context)
        {
            _context = context;
        }

        public class ItemAdd
        {
            public int ItemID { get; set; }
            public int CategoryId { get; set; }
            public string ItemName { get; set; }
            public string ItemDescription { get; set; }
            public string Price { get; set; }
            public string ImageData { get; set; }
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            if (_context.Items == null)
            {
                return NotFound();
            }

            return await _context.Items.ToListAsync();
        }

        [HttpPost("addItem")]
        public async Task<IActionResult> AddItem([FromBody] ItemAdd addedItem)
        {
            Console.WriteLine($"Received Image Data: {addedItem.ImageData.Length} bytes");

            var imageDataBytes = Convert.FromBase64String(addedItem.ImageData);

            // Save image to the Images table
            var image = new Image
            {
                Title = addedItem.ItemName,
                ImageData = imageDataBytes
            };

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            // create new user object
            Item newItem = new Item
            {
                CategoryId = addedItem.CategoryId,
                ItemName = addedItem.ItemName,
                ItemDescription = addedItem.ItemDescription,
                Price = double.Parse(addedItem.Price),
                ImageId = image.ImageId
            };

            // add item to DB
            _context.Items.Add(newItem);
            await _context.SaveChangesAsync();

            // return success
            return Ok(true);
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            if (_context.Items == null)
            {
                return Problem("Entity set 'ProjectDBContext.Items'  is null.");
            }
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return (_context.Items?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
