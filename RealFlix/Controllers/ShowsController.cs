using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealFlix.Data;
using RealFlix.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace RealFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly RealFlixContext _context;
        private readonly IDataRepository<Show> _repo;

        public ShowsController(RealFlixContext context, IDataRepository<Show> repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/Shows
        [HttpGet]
        public ActionResult<IEnumerable<Show>> GetShow()
        {
            return _context.Show.OrderBy(s => s.Name).ToList();
        }

        // GET: api/Shows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> GetShow(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var show = await _context.Show.FindAsync(id);

            if (show == null)
            {
                return NotFound();
            }

            return Ok(show);
        }

        [HttpGet("~/api/shows/Search")]
        public ActionResult<IEnumerable<Show>> Search(string searchType, string searchCriteria)
        {
            var result = new List<Show>();
            if (searchType != "Schedule")
            {
                var query = $"{searchType}.Contains(\"{searchCriteria}\")";
                // using this package System.Linq.Dynamic.Core to allow run queries from string variables
                result = _context.Show.Where(query).ToList();
            }
            else
            {
                // scheduled time is splitted into day and time values
                var scheduleInfo = searchCriteria.Split('|');
                var day = scheduleInfo[0].Trim();
                // day and time provided
                if (scheduleInfo.Length > 1)
                {
                    var time = scheduleInfo[1].Trim();
                    result = _context.Show.Where(x => x.ScheduledDays == day && x.ScheduledTime.Contains(time)).ToList();
                }
                // only day provided
                else
                {
                    result = _context.Show.Where(x => x.ScheduledDays == day).ToList();
                }
            }
            return result;
        }

        // PUT: api/Shows/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShow(int id, Show show)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != show.Id)
            {
                return BadRequest();
            }

            _context.Entry(show).State = EntityState.Modified;

            try
            {
                _repo.Update(show);
                var save = await _repo.SaveAsync(show);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(true);
        }

        // POST: api/Shows
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Show>> PostShow(Show show)
        {
            _context.Show.Add(show);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShow", new { id = show.Id }, show);
        }

        // DELETE: api/Shows/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Show>> DeleteShow(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var show = await _context.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            _repo.Delete(show);
            var save = await _repo.SaveAsync(show);

            return Ok(show);
        }

        private bool ShowExists(int id)
        {
            return _context.Show.Any(e => e.Id == id);
        }
    }
}
