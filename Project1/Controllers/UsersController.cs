using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMSWebpage.Model;
using System.Text;

namespace CMSWebpage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public class UserLogin
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class UserRegister
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Office { get; set; }
            public string Number { get; set; }
            public int Role { get; set; }
        }

        string hashPassword(string password)
        {
            var sha = SHA256.Create();

            var byteArray = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(byteArray);

            return Convert.ToBase64String(hashedPassword);
        }

        public UsersController(ProjectDBContext context)
        {
            _context = context;
        }

        [HttpPost("reg")]
        public async Task<IActionResult> Register([FromBody] UserRegister userRegister)
        {
            // hash password
            string hashedPassword = hashPassword(userRegister.Password);

            // create new user object
            User newUser = new User
            {
                Name = userRegister.Name,
                Email = userRegister.Email,
                Password = hashedPassword,
                Office = userRegister.Office,
                Number = userRegister.Number,
                Role = userRegister.Role.ToString()
            };

            // add user to DB
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // return success
            return Ok(true);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            // get user info from DB
            User user = await _context.Users.SingleOrDefaultAsync(u => u.Email == userLogin.Email);

            if (user != null)
            {
                // confirm if user password is correct
                if (user.Password == hashPassword(userLogin.Password))
                {
                    // return success
                    return Ok(true);
                }
            }

            // incorrect username or password
            return Ok(false);
        }

        // GET: api/userRole
        [HttpGet("getRole/{email}")]
        public async Task<ActionResult<int>> GetUsers(string email)
        {

            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            int roleID = Convert.ToInt32(user.Role);

            return roleID;

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserRole(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ProjectDBContext.Users'  is null.");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
