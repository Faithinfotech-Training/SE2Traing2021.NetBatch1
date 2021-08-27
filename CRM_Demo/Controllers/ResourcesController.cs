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

namespace CRM_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourcesController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet(nameof(getAllResource))]
        public IActionResult getAllResource()
        {
            var res = _resourceService.GetAllResources();
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpGet(nameof(getResource))]
        public IActionResult getResource(int id)
        {
            var res = _resourceService.GetResource(id);
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpPost(nameof(insertResource))]
        public IActionResult insertResource(resource resource)
        {
            _resourceService.InsertResource(resource);
            return Ok("Data Saved SuccessFully");
        }


        [HttpPut(nameof(updateResource))]
        public IActionResult updateResource(resource resource)
        {
            _resourceService.UpdateResource(resource);
            return Ok("Data Updated Successfully");
        }

        [HttpDelete(nameof(deleteResource))]
        public IActionResult deleteResource(int id)
        {
            _resourceService.DeletetResource(id);
            return Ok("Data Deleted Successfully");
        }

    }
}
