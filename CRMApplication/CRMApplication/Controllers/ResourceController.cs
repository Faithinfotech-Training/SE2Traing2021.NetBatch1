using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ResourceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
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
            return Ok("Resource Saved SuccessFully");
        }


        [HttpPut(nameof(UpdateResource))]
        public IActionResult UpdateResource(Resource resource)
        {
            _resourceService.UpdateResource(resource);
            return Ok("Resource Updated Successfully");
        }

        [HttpDelete(nameof(DeleteResource))]
        public IActionResult DeleteResource(int id)
        {
            _resourceService.DeletetResource(id);
            return Ok("Resource Deleted Successfully");
        }
    }
}
