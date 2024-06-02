using AddressBook.Data.Contexts;
using AddressBook.Domain.Contracts;
using AddressBook.Domain.DTOs.Job;
using AddressBook.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly AddressBookDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public JobsController(AddressBookDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetJobsDTO>>> GetJobs()
        { 
          return  await _unitOfWork.Repository<Job>().GetAllAsync<GetJobsDTO>();
        }

        //GET: api/Jobs/5
            [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        //    // PUT: api/Jobs/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutJob(int id, Job job)
        //    {
        //        if (id != job.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(job).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!JobExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Jobs
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<Job>> PostJob(Job job)
        //    {
        //        _context.Jobs.Add(job);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetJob", new { id = job.Id }, job);
        //    }

        //    // DELETE: api/Jobs/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteJob(int id)
        //    {
        //        var job = await _context.Jobs.FindAsync(id);
        //        if (job == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Jobs.Remove(job);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool JobExists(int id)
        //    {
        //        return _context.Jobs.Any(e => e.Id == id);
        //    }
    }
}
