using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using CRM_Demo.Models;
using Domain_Layer.Models;
using Service_Layer.Services;

namespace CRManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        /*        private readonly CRMdbContext _context;

                public ResourcesController(CRMdbContext context)
                {
                    _context = context;
                }

                // GET: api/Resources
                [HttpGet]
                public async Task<ActionResult<IEnumerable<Resource>>> GetResources()
                {
                    return await _context.Resources.ToListAsync();
                }



                // GET: api/Resources/5
                [HttpGet("{id}")]
                public async Task<ActionResult<Resource>> GetResource(int id)
                {
                    var resource = await _context.Resources.FindAsync(id);

                    if (resource == null)
                    {
                        return NotFound();
                    }

                    return resource;
                }

                // GET: api/Resources/5
                [HttpGet("/Resources/{Availablestatus}")]
                public IEnumerable<Resource> GetResourcebyAvaiStatus(bool Availablestatus)
                {
                    var user = _context.Resources.Where(user => user.ResourceAvaiStatus == Availablestatus);
                    if (user == null)
                    {
                        return (IEnumerable<Resource>)NotFound();
                    }
                    return user;
                }

                // GET: api/Resources
                [HttpGet("/ResourcesCount/")]
                public async Task<ActionResult<IEnumerable<Resource>>> GetResourcesCount()
                {
                    var user = await _context.Resources.FromSqlRaw("select count(*) from Resources").ToListAsync();
                    return user;
                }


                // PUT: api/Resources/5
                // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPut("{id}")]
                public async Task<IActionResult> PutResource(int id, Resource resource)
                {
                    if (id != resource.ResourceId)
                    {
                        return BadRequest();
                    }

                    _context.Entry(resource).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ResourceExists(id))
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

                // POST: api/Resources
                // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPost]
                public async Task<ActionResult<Resource>> PostResource(Resource resource)
                {
                    _context.Resources.Add(resource);
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        if (ResourceExists(resource.ResourceId))
                        {
                            return Conflict();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    return CreatedAtAction("GetResource", new { id = resource.ResourceId }, resource);
                }

                // DELETE: api/Resources/5
                [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteResource(int id)
                {
                    var resource = await _context.Resources.FindAsync(id);
                    if (resource == null)
                    {
                        return NotFound();
                    }

                    _context.Resources.Remove(resource);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }

                private bool ResourceExists(int id)
                {
                    return _context.Resources.Any(e => e.ResourceId == id);
                }*/
        private readonly IResourceService _resourceService;

        public ResourcesController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet(nameof(GetAllResource))]
        public IActionResult GetAllResource()
        {
            var res = _resourceService.GetAllResources();
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpGet(nameof(GetResource))]
        public IActionResult GetResource(int id)
        {
            var res = _resourceService.GetResource(id);
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpPost(nameof(InsertResource))]
        public IActionResult InsertResource(Resource resource)
        {
            _resourceService.InsertResource(resource);
            return Ok("Data Saved SuccessFully");
        }


        [HttpPut(nameof(UpdateResource))]
        public IActionResult UpdateResource(Resource resource)
        {
            _resourceService.UpdateResource(resource);
            return Ok("Data Updated Successfully");
        }

        [HttpDelete(nameof(DeleteResource))]
        public IActionResult DeleteResource(int id)
        {
            _resourceService.DeletetResource(id);
            return Ok("Data Deleted Successfully");
        }

    }
}
