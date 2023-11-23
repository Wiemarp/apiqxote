
using apiqxote.databaseqxote;
using apiqxote.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiqxote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        private readonly DatabaseqxoteContext _context;

        public AnimalController(DatabaseqxoteContext context)
        {
            _context = context;
        }

        // GET: api/<AnimalController>
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
            return Ok(_context.Animals.ToList());
        }

        // GET api/<AnimalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AnimalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AnimalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnimalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
