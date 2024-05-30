using AddressBook.API.Errors;
using AddressBook.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestErrorsController : ControllerBase
    {
        private readonly AddressBookDbContext _context;
        public TestErrorsController(AddressBookDbContext context)
        {
            _context = context;
        }
        [HttpGet("notFound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Persons.Find(555);
            if (thing is null)
            {
                return NotFound(new APIResponse(404));
            }
            return Ok();
        }
        [HttpGet("serverError")]
        public ActionResult GetServerError()
        {
            var thing = _context.Persons.Find(555);
            var thingToRetrun = thing.ToString();
            return Ok();
        }
        [HttpGet("badRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new APIResponse(400));
        }
        [HttpGet("badRequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
        //[Authorize]
        //[HttpGet("secretText")]
        //public ActionResult<string> GetSecretText()
        //{
        //    return "this is secret text ";
        //}

    }
}
