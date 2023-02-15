using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trackingapi.Data;
using trackingapi.Model;

namespace trackingapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class issueController : ControllerBase
    {
        private readonly issueDbContext _db;
        //issue needs to access database...Constructor
        public issueController(issueDbContext db) => _db = db;
        [HttpGet]
        [ProducesResponseType(typeof(issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<issue>> Get()
            => await _db.Issues.ToListAsync();
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _db.Issues.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(issue Issue)
        {
            await _db.Issues.AddAsync(Issue);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { Id = Issue.id }, Issue);
        }
        //place holder id represents that id will be available in url
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, issue Issue)
        {
            //check if there mismatch between the id in url and id in body
            if (id != Issue.id) return BadRequest();
            _db.Entry(Issue).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {   
            //check if the issue exists 
            var issueToDelete = await _db.Issues.FindAsync(id);
            if (issueToDelete == null) return NotFound();

            _db.Issues.Remove(issueToDelete);
            await _db.SaveChangesAsync();

            return NoContent();
        }

    }
}
