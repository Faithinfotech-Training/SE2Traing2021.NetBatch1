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

namespace CRManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceEnquiriesController : ControllerBase
    {
        private readonly CRMdbContext _context;
        private readonly IResourseEnquiry _courseEnquiryServices;
        public ResourceEnquiriesController(IResourseEnquiry courseEnquiryServices)

        {
            _courseEnquiryServices = courseEnquiryServices;
        }

        [HttpGet(nameof(GetAllResourceEnquiry))]
        public IActionResult GetAllResourceEnquiry()
        {
            var res = _courseEnquiryServices.GetAllCourseEnquiry();
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpGet(nameof(GetResourceEnquiry))]
        public IActionResult GetResourceEnquiry(int id)
        {
            var res = _courseEnquiryServices.GetCourseEnquiry(id);
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpPost(nameof(InsertResourceEnquiry))]
        public IActionResult InsertResourceEnquiry(ResourseEnquiry course)
        {
            _courseEnquiryServices.InsertCourse(course);
            return Ok("Data Saved SuccessFully");
        }


        [HttpPut(nameof(UpdateCourseEnquiry))]
        public IActionResult UpdateCourseEnquiry(ResourseEnquiry course)
        {
            _courseEnquiryServices.UpdateCourse(course);
            return Ok("Data Updated Successfully");
        }

        [HttpDelete(nameof(DeleteCourseEnquiry))]
        public IActionResult DeleteCourseEnquiry(int id)
        {
            _courseEnquiryServices.DeleteCourse(id);
            return Ok("Data Deleted Successfully");
        }

    }
}
