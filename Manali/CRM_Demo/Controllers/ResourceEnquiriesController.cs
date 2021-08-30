using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM_Demo.Models;
using Domain_Layer.Models;
using Repository_Layer;
using Service_Layer.Services;

namespace CRM_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceEnquiriesController : ControllerBase
    {
        //private readonly CRMdbContext _context;
        private readonly IResourceEnquiryService _ResourceEnquiryService;
        public ResourceEnquiriesController(IResourceEnquiryService resourceEnquiryService)

        {
            _ResourceEnquiryService = resourceEnquiryService;
        }

        [HttpGet(nameof(getAllResourceEnquiry))]
        public IActionResult getAllResourceEnquiry()
        {
            var res = _ResourceEnquiryService.GetAllResourceEnquiry();
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpGet(nameof(getResourceEnquiry))]
        public IActionResult getResourceEnquiry(int id)
        {
            var res = _ResourceEnquiryService.GetResourceEnquiry(id);
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpPost(nameof(insertResourceEnquiry))]
        public IActionResult insertResourceEnquiry(resourceEnquiry resourceEnquiry)
        {
            _ResourceEnquiryService.InsertResourceEnquiry(resourceEnquiry);
            return Ok("Data Saved SuccessFully");
        }


        [HttpPut(nameof(updateResourceEnquiry))]
        public IActionResult updateResourceEnquiry(resourceEnquiry resourceEnquiry)
        {
            _ResourceEnquiryService.UpdateResourceEnquiry(resourceEnquiry);
            return Ok("Data Updated Successfully");
        }

        [HttpDelete(nameof(deleteResourceEnquiry))]
        public IActionResult deleteResourceEnquiry(int id)
        {
            _ResourceEnquiryService.DeleteResourceEnquiry(id);
            return Ok("Data Deleted Successfully");
        }

        [HttpGet("status/{Status}")]
        public IActionResult GetStatusBasedEnquiries(String Status)
        {
            return Ok(_ResourceEnquiryService.getStatusBasedEnquiries(Status));
        }
    }
}
