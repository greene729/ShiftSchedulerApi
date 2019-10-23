using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftSchedulerApi.Data;
using ShiftSchedulerApi.Models;

namespace ShiftSchedulerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShiftsController : ControllerBase
    {
        private ShiftSchedulerDbContext _shiftSchedulerDbContext;

        public ShiftsController(ShiftSchedulerDbContext shiftSchedulerDbContext)
        {
            _shiftSchedulerDbContext = shiftSchedulerDbContext;
        }

        // GET: api/Shifts
        [HttpGet]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client)]
        public IActionResult Get(string sort)
        {
            IQueryable<Shift> shifts;

            switch (sort)
            {
                case "desc":
                    shifts = _shiftSchedulerDbContext.Shifts.OrderByDescending(s => s.Start);
                    break;
                case "asc":
                    shifts = _shiftSchedulerDbContext.Shifts.OrderBy(s => s.Start);
                    break;
                default:
                    shifts = _shiftSchedulerDbContext.Shifts;
                    break;
            }

            return Ok(shifts);
        }

        // GET: api/Shifts/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var shift = _shiftSchedulerDbContext.Shifts.Find(id);
            if(shift == null)
            {
                return NotFound("No shift with that id");
            }
            else
            {
                return Ok(shift);
            }
        }

        // POST: api/Shifts
        [HttpPost]
        public IActionResult Post([FromBody] Shift shift)
        {
            _shiftSchedulerDbContext.Shifts.Add(shift);
            _shiftSchedulerDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Shifts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Shift shift)
        {
            var entity = _shiftSchedulerDbContext.Shifts.Find(id);
            if (entity == null)
            {
                return NotFound("No shift with that id");
            }
            else
            {
                entity.Start = shift.Start;
                entity.End = shift.End;
                entity.Description = shift.Description;
                entity.CreatedByUserId = shift.CreatedByUserId;
                entity.Attendees = shift.Attendees;
                _shiftSchedulerDbContext.SaveChanges();
                return Ok("Shift updated successfully");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var shift = _shiftSchedulerDbContext.Shifts.Find(id);
            if(shift == null)
            {
                return NotFound("No shift with that id");
            }
            else
            {
                _shiftSchedulerDbContext.Shifts.Remove(shift);
                _shiftSchedulerDbContext.SaveChanges();
                return Ok("Shift deleted");
            }
        }
    }
}
