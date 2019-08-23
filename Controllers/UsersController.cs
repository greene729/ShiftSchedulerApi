using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftSchedulerApi.Data;
using ShiftSchedulerApi.Models;

namespace ShiftSchedulerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ShiftSchedulerDbContext _shiftSchedulerDbContext;

        public UsersController(ShiftSchedulerDbContext shiftSchedulerDbContext)
        {
            _shiftSchedulerDbContext = shiftSchedulerDbContext;
        }

        // GET: api/Users
        [HttpGet]
        [ResponseCache(Duration = 60, Location =ResponseCacheLocation.Client)]
        public IActionResult Get(string sort)
        {
            IQueryable<User> users;
            switch (sort)
            {
                case "desc":
                    users = _shiftSchedulerDbContext.Users.OrderByDescending(u => u.Name);
                    break;
                case "asc":
                    users = _shiftSchedulerDbContext.Users.OrderBy(u => u.Name);
                    break;
                default:
                    users = _shiftSchedulerDbContext.Users.OrderBy(u => u.Id);
                    break;
            }
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var user = _shiftSchedulerDbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound("No User with that id");
            }
            else
            {
                return Ok(user);
            }
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _shiftSchedulerDbContext.Users.Add(user);
            _shiftSchedulerDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            var entity = _shiftSchedulerDbContext.Users.Find(id);
            if(entity == null)
            {
                return NotFound("No User with that id");
            }
            else
            {
                entity.Name = user.Name;
                entity.Email = user.Email;
                entity.PhoneNumber = user.PhoneNumber;
                _shiftSchedulerDbContext.SaveChanges();
                return Ok("Record Updated Successfully");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
