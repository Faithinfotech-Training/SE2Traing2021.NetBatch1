using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRManagement.Models;

namespace CRManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourseEnquiriesController : ControllerBase
    {
        private readonly CRMdbContext _context;

        public ResourseEnquiriesController(CRMdbContext context)
        {
            _context = context;
        }

        // GET: api/ResourseEnquiries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourseEnquiry>>> GetResourseEnquiries()
        {
            return await _context.ResourseEnquiries.ToListAsync();
        }

        // GET: api/ResourseEnquiries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResourseEnquiry>> GetResourseEnquiry(int id)
        {
            var resourseEnquiry = await _context.ResourseEnquiries.FindAsync(id);

            if (resourseEnquiry == null)
            {
                return NotFound();
            }

            return resourseEnquiry;
        }

        // PUT: api/ResourseEnquiries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResourseEnquiry(int id, ResourseEnquiry resourseEnquiry)
        {
            if (id != resourseEnquiry.ResourceEnquiryId)
            {
                return BadRequest();
            }

            _context.Entry(resourseEnquiry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourseEnquiryExists(id))
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

        // POST: api/ResourseEnquiries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResourseEnquiry>> PostResourseEnquiry(ResourseEnquiry resourseEnquiry)
        {
            _context.ResourseEnquiries.Add(resourseEnquiry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResourseEnquiryExists(resourseEnquiry.ResourceEnquiryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResourseEnquiry", new { id = resourseEnquiry.ResourceEnquiryId }, resourseEnquiry);
        }

        // DELETE: api/ResourseEnquiries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResourseEnquiry(int id)
        {
            var resourseEnquiry = await _context.ResourseEnquiries.FindAsync(id);
            if (resourseEnquiry == null)
            {
                return NotFound();
            }

            _context.ResourseEnquiries.Remove(resourseEnquiry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResourseEnquiryExists(int id)
        {
            return _context.ResourseEnquiries.Any(e => e.ResourceEnquiryId == id);
        }
    }
}
