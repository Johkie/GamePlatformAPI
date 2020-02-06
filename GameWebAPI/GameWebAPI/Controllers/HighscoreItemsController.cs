using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameWebAPI.Models;

namespace GameWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighscoreItemsController : ControllerBase
    {
        private readonly HighscoreContext _context;

        public HighscoreItemsController(HighscoreContext context)
        {
            _context = context;
        }

        // GET: api/HighscoreItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HighscoreItem>>> GetHighscoreItems()
        {
            return await _context.HighscoreItems.ToListAsync();
        }

        // GET: api/HighscoreItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HighscoreItem>> GetHighscoreItem(int id)
        {
            var highscoreItem = await _context.HighscoreItems.FindAsync(id);

            if (highscoreItem == null)
            {
                return NotFound();
            }

            return highscoreItem;
        }

        // PUT: api/HighscoreItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHighscoreItem(int id, HighscoreItem highscoreItem)
        {
            if (id != highscoreItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(highscoreItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HighscoreItemExists(id))
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

        // POST: api/HighscoreItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<HighscoreItem>> PostHighscoreItem(HighscoreItem highscoreItem)
        {
            _context.HighscoreItems.Add(highscoreItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHighscoreItem), new { id = highscoreItem.Id }, highscoreItem);
        }

        // DELETE: api/HighscoreItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HighscoreItem>> DeleteHighscoreItem(int id)
        {
            var highscoreItem = await _context.HighscoreItems.FindAsync(id);
            if (highscoreItem == null)
            {
                return NotFound();
            }

            _context.HighscoreItems.Remove(highscoreItem);
            await _context.SaveChangesAsync();

            return highscoreItem;
        }

        private bool HighscoreItemExists(int id)
        {
            return _context.HighscoreItems.Any(e => e.Id == id);
        }
    }
}
