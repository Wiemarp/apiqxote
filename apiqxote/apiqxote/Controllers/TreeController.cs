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
    public class TreeController : ControllerBase  
    {
        private readonly DatabaseqxoteContext _context;
        private readonly IMapper _mapper;

        public TreeController(DatabaseqxoteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<AnimalController>
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<TreeName>>> GetTrees()
        {
            return Ok(_context.Trees.ToList());
        }

        // POST api/<AnimalController>
        [HttpPost]
        public async Task<ActionResult<TreeDTO>> Post(TreeDTO tree)
        {
            if (_context.Zones == null)
            {
                return Problem("Entity set is null.");
            }
            Tree treeToAdd = _mapper.Map<Tree>(tree);
            _context.Trees.Add(treeToAdd);
            await _context.SaveChangesAsync();

            tree.TreeNr = treeToAdd.TreeNr;
            return Ok(tree);
        }

        // PUT api/<AnimalController>/5
        [HttpPut("{zoneName}")]
        public async Task<ActionResult<AnimalDTO>> Put(string zoneName, ZoneDTO zone)
        {
            if (zoneName != zone.Zone1)
            {
                return BadRequest();
            }
            if (_context.Animals == null)
            {
                return Problem("Entity set is null.");
            }
            Zone zoneToEdit = _mapper.Map<Zone>(zone);
            _context.Entry(zoneToEdit).State = EntityState.Modified;


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
        [HttpDelete("{zoneName}")]
        public async Task<IActionResult> Delete(string zoneName)
        {
            if (_context.Animals == null)
            {
                return Problem("Entity set is null.");
            }
            var zone = await _context.Zones.FindAsync(zoneName);
            if (zone == null)
            {
                return NotFound();
            }

            _context.Remove(zone);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
