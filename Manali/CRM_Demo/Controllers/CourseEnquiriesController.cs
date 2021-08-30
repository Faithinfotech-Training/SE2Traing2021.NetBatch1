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
    public class CourseEnquiriesController : ControllerBase
    {
       // private readonly CRMdbContext _context;
        private readonly ICourseEnquiryService _courseEnquiryServices;
        public CourseEnquiriesController(ICourseEnquiryService courseEnquiryServices)

        {
            _courseEnquiryServices = courseEnquiryServices;
        }

        [HttpGet(nameof(getAllCourseEnquiry))]
        public IActionResult getAllCourseEnquiry()
        {
            var res = _courseEnquiryServices.GetAllCourseEnquiry();
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpGet(nameof(getCourseEnquiry))]
        public IActionResult getCourseEnquiry(int id)
        {
            var res = _courseEnquiryServices.GetCourseEnquiry(id);
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpPost(nameof(insertCourseEnquiry))]
        public IActionResult insertCourseEnquiry(courseEnquiry course)
        {
            _courseEnquiryServices.InsertCourseEnquiry(course);
            return Ok("Data Saved SuccessFully");
        }


        [HttpPut(nameof(updateCourseEnquiry))]
        public IActionResult updateCourseEnquiry(courseEnquiry course)
        {
            _courseEnquiryServices.UpdateCourseEnquiry(course);
            return Ok("Data Updated Successfully");
        }

        [HttpDelete(nameof(deleteCourseEnquiry))]
        public IActionResult deleteCourseEnquiry(int id)
        {
            _courseEnquiryServices.DeleteCourseEnquriy(id);
            return Ok("Data Deleted Successfully");
        }

        [HttpGet("status/{Status}")]
        public IActionResult GetStatusBasedEnquiries(String Status)
        {
            return Ok(_courseEnquiryServices.getStatusBasedEnquiries(Status));
        }

    }
}
