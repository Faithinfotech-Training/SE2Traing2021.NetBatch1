using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM_Demo.Models;
using Domain_Layer.Models;
using Service_Layer.Services;

namespace CRM_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
     {
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet(nameof(getAllCourse))]
    public IActionResult getAllCourse()
    {
        var res = _courseService.GetAllCourses();
        if (res is not null)
        {
            return Ok(res);
        }
        return BadRequest("No Record Found");
    }

    [HttpGet(nameof(getCourse))]
    public IActionResult getCourse(int id)
    {
        var res = _courseService.GetCourse(id);
        if (res is not null)
        {
            return Ok(res);
        }
        return BadRequest("No Record Found");
    }

    [HttpPost(nameof(insertCourse))]
    public IActionResult insertCourse(course course)
    {
        _courseService.InsertCourse(course);
        return Ok("Data Saved SuccessFully");
    }


    [HttpPut(nameof(updateCourse))]
    public IActionResult updateCourse(course course)
    {
        _courseService.UpdateCourse(course);
        return Ok("Data Updated Successfully");
    }

    [HttpDelete(nameof(deleteCourse))]
    public IActionResult deleteCourse(int id)
    {
        _courseService.DeleteCourse(id);
        return Ok("Data Deleted Successfully");
    }

}
}
