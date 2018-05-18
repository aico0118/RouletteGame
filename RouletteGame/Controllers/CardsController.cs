using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouletteGame.Models;

namespace RouletteGame.Controllers
{
    [Produces("application/json")]
    [Route("api/Cards")]
    public class CardsController : Controller
    {
        private readonly RoulettegameContext _context;

        public CardsController()
        {
            _context = new RoulettegameContext();
        }

        // GET: api/Cards
        [HttpGet]
        public IEnumerable<Card> GetCard()
        {
            return _context.Card;
        }

        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var card = await _context.Card.SingleOrDefaultAsync(m => m.Id == id);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        // PUT: api/Cards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard([FromRoute] int id, [FromBody] Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != card.Id)
            {
                return BadRequest();
            }

            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cards
        [HttpPost]
        public async Task<IActionResult> PostCard([FromBody] Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Card.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCard", new { id = card.Id }, card);
        }

        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var card = await _context.Card.SingleOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            _context.Card.Remove(card);
            await _context.SaveChangesAsync();

            return Ok(card);
        }

        private bool CardExists(int id)
        {
            return _context.Card.Any(e => e.Id == id);
        }
    }
}