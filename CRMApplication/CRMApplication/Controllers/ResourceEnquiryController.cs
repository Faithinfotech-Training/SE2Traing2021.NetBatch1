using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ResourceEnquiryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceEnquiryController : ControllerBase
    {

        private readonly IResourceEnquiryService _resourceService;

        public ResourceEnquiryController(IResourceEnquiryService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet(nameof(GetAllEnquiries))]
        public IActionResult GetAllEnquiries()
        {
            var res = _resourceService.GetAllResourcesEnquiry();
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpGet(nameof(GetEnquiry))]
        public IActionResult GetEnquiry(int id)
        {
            var res = _resourceService.GetResourceEnquiry(id);
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpPost(nameof(InsertEnquiry))]
        public IActionResult InsertEnquiry(ResourceEnquiry resource)
        {
            _resourceService.InsertResourceEnquiry(resource);
            return Ok("Resource Enquiry Saved SuccessFully");
        }


        [HttpPut(nameof(UpdateEnquiry))]
        public IActionResult UpdateEnquiry(ResourceEnquiry course)
        {
            _resourceService.UpdateResourceEnquiry(course);
            return Ok("Resource Enquiry Updated Successfully");
        }

        [HttpDelete(nameof(DeleteEnquiry))]
        public IActionResult DeleteEnquiry(int id)
        {
            _resourceService.DeleteResourceEnquiry(id);
            return Ok("Resource Enquiry Deleted Successfully");
        }

    }
}

