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
    public class CourseEnquiriesController : ControllerBase
    {
        private readonly CRMdbContext _context;
        private readonly ICourseEnquiryService _courseEnquiryServices;
        public CourseEnquiriesController(ICourseEnquiryService courseEnquiryServices)

        {
            _courseEnquiryServices = courseEnquiryServices;
        }

        [HttpGet(nameof(GetAllCourseEnquiry))]
        public IActionResult GetAllCourseEnquiry()
        {
            var res = _courseEnquiryServices.GetAllCourseEnquiry();
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpGet(nameof(GetCourseEnquiry))]
        public IActionResult GetCourseEnquiry(int id)
        {
            var res = _courseEnquiryServices.GetCourseEnquiry(id);
            if (res is not null)
            {
                return Ok(res);
            }
            return BadRequest("No Record Found");
        }

        [HttpPost(nameof(InsertCourseEnquiry))]
        public IActionResult InsertCourseEnquiry(CourseEnquiry course)
        {
            _courseEnquiryServices.InsertCourse(course);
            return Ok("Data Saved SuccessFully");
        }


        [HttpPut(nameof(UpdateCourseEnquiry))]
        public IActionResult UpdateCourseEnquiry(CourseEnquiry course)
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
