using AddressBook.Data.Contexts;
using AddressBook.Domain.Contracts;
using AddressBook.Domain.DTOs.Departments;
using AddressBook.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AddressBookDbContext _context;

        private readonly IUnitOfWork _unitOfWork;

        public DepartmentsController(AddressBookDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _context = context;

            _unitOfWork = unitOfWork;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDepartmentsDTO>>> GetDepartments(int? JobId)
        {
            return JobId is not null ? await _unitOfWork.Repository<Department>().GetAllAsync<GetDepartmentsDTO>(d => d.JobId == JobId) :
                     await _unitOfWork.Repository<Department>().GetAllAsync<GetDepartmentsDTO>() ;

        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutDepartment(int id, Department department)
        //    {
        //        if (id != department.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(department).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DepartmentExists(id))
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

        //    // POST: api/Departments
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<Department>> PostDepartment(Department department)
        //    {
        //        _context.Departments.Add(department);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        //    }

        //    // DELETE: api/Departments/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteDepartment(int id)
        //    {
        //        var department = await _context.Departments.FindAsync(id);
        //        if (department == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Departments.Remove(department);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool DepartmentExists(int id)
        //    {
        //        return _context.Departments.Any(e => e.Id == id);
        //    }
    }
}
