using AddressBook.API.Errors;
using AddressBook.API.QueryPrams;
using AddressBook.Data.Contexts;
using AddressBook.Data.Helper;
using AddressBook.Domain.Contracts;
using AddressBook.Domain.DTOs.Person;
using AddressBook.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Linq.Expressions;

namespace AddressBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
    
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public PersonsController( IUnitOfWork unitOfWork, IMapper mapper,IConfiguration configuration)
        {
         
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<Paging<GetPagingPersonsDTO>>> GetPersons([FromQuery] GetAllPersonsParams personsParams)
        {
            Expression<Func<Person, object>> sortAsc = default;
            Expression<Func<Person, object>> sortDesc = default;
            Expression<Func<Person, bool>> filter = p =>
            (string.IsNullOrEmpty(personsParams.FullName) || p.FullName.ToLower().Contains(personsParams.FullName)) &&
            (string.IsNullOrEmpty(personsParams.Email) || p.Email.Contains(personsParams.Email)) &&
            (string.IsNullOrEmpty(personsParams.City) || p.City.ToLower().Contains(personsParams.City)) &&
            (!personsParams.BirthDate.HasValue || p.BirthDate == personsParams.BirthDate) &&
            (!personsParams.DepartmentId.HasValue || p.Department.Id == personsParams.DepartmentId) &&
            (!personsParams.JobId.HasValue || p.Department.Job.Id == personsParams.JobId);
            switch (personsParams.Sort)
            {
                case "cityAsc":
                    sortAsc = p => p.City;
                    break;
                case "cityDesc":
                    sortDesc = p => p.City;
                    break;        
                case "nameDesc":
                    sortDesc = p => p.FullName;
                    break;
                default:
                    sortAsc = p => p.FullName;
                    break;
            }
            List<GetPagingPersonsDTO> persons = await _unitOfWork.Repository<Person>()
                .GetAllAsync<GetPagingPersonsDTO>(personsParams.PageIndex, personsParams.PageSize, filter, sortAsc, sortDesc, p => p.Department, p => p.Department.Job);
            if (persons is not null) persons.ForEach(e => e.ImageUrl = _configuration["APIURL"]+"//" + e.ImageUrl);
            var personsCount = await _unitOfWork.Repository<Person>().GetCountAsync(filter);
            return Ok(new Paging<GetPagingPersonsDTO>()
            {
                Count = personsCount,
                Data = persons,
                PageIndex = personsParams.PageIndex,
                PageSize = personsParams.PageSize

            });

        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPersonDTO>> GetPerson(int id)
        {
            var person = await _unitOfWork.Repository<Person>().GetAsync<GetPersonDTO>(p => p.Id == id);

            if (person == null)
            {
                return NotFound(new APIResponse(404));
            }
            person.ImageUrl = _configuration["APIURL"] + "//" + person.ImageUrl;
            return Ok(person);
        }

        // PUT: api/Persons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, PutPersonDTO putPersonDTO)
        {
            if (id != putPersonDTO.Id)
            {
                return BadRequest(new APIResponse(400));
            }
            Person person = _mapper.Map<Person>(putPersonDTO);
            _unitOfWork.Repository<Person>().Update(person);


            try
            {
              await  _unitOfWork.CompleteAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PersonExists(id))
                {
                    return NotFound(new APIResponse(404));
                }
                else
                {
                    return BadRequest(new APIResponse(400));
                }
            }

            return NoContent();
        }

        // POST: api/Persons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetPersonDTO>> PostPerson( PostPersonDTO personDTO)
        {

            var person = _mapper.Map<Person>(personDTO);
            _unitOfWork.Repository<Person>().Add(person);
            int result = await _unitOfWork.CompleteAsync();
            if (result > 0)
            {
              
                return CreatedAtAction("GetPerson",new {id=person.Id}, person);
            }
            else
                return BadRequest(new APIResponse(400, "cant create this person"));


        }  
       

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _unitOfWork.Repository<Person>().FindById(id);

            if (person is null)
            {
                return NotFound();
            }

            _unitOfWork.Repository<Person>().Delete(person);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        private async Task<bool> PersonExists(int id)
        {
            return await _unitOfWork.Repository<Person>().Exists(p => p.Id == id);
        }
    }
}
