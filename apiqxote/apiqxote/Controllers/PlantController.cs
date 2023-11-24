using apiqxote.databaseqxote;
using apiqxote.DTOModels;
using apiqxote.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace apiqxote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase  
    {
        private readonly DatabaseqxoteContext _context;
        private readonly IMapper _mapper;

        public PlantController(DatabaseqxoteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<AnimalController>
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<TreeName>>> GetPlantNames()
        {
            return Ok(_context.Plants.ToList());
        }

        // POST api/<AnimalController>
        [HttpPost]
        public async Task<ActionResult<PlantDTO>> Post(PlantDTO plant)
        {
            if (_context.Zones == null)
            {
                return Problem("Entity set is null.");
            }
            Plant plantToAdd = _mapper.Map<Plant>(plant);
            _context.Plants.Add(plantToAdd);
            await _context.SaveChangesAsync();

            plant.PlantId = plantToAdd.PlantId;
            return Ok(plant);
        }

        // PUT api/<AnimalController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AnimalDTO>> Put(int id, PlantDTO plant)
        {
            if (id != plant.PlantId)
            {
                return BadRequest();
            }
            if (_context.Animals == null)
            {
                return Problem("Entity set is null.");
            }
            Plant plantToEdit = _mapper.Map<Plant>(plant);
            _context.Entry(plantToEdit).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE api/<AnimalController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Animals == null)
            {
                return Problem("Entity set is null.");
            }
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }

            _context.Remove(plant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
