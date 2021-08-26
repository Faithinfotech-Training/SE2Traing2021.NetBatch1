using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM_Demo.Models;
using Domain_Layer.Models;
using Service_Layer.Services;

namespace CRManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
     {
      /*   private readonly CRMdbContext _context;

         public CoursesController(CRMdbContext context)
         {
             _context = context;
         }

         // GET: api/Courses
         [HttpGet]
         public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
         {
             return await _context.Courses.ToListAsync();
         }

         // GET: api/Courses/5
         [HttpGet("{id}")]
         public async Task<ActionResult<Course>> GetCourse(int id)
         {
             var course = await _context.Courses.FindAsync(id);

             if (course == null)
             {
                 return NotFound();
             }

             return course;
         }
         // GET: api/Courses/5
         [HttpGet("/Courses/{Availablestatus}")]
         public IEnumerable<Course> GetCoursebyAvaiStatus(bool Availablestatus)
         {
             var user = _context.Courses.Where(user => user.CourseAvaiStatus == Availablestatus);
             if (user == null)
             {
                 return (IEnumerable<Course>)NotFound();
             }
             return user;
         }


         // PUT: api/Courses/5
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPut("{id}")]
         public async Task<IActionResult> PutCourse(int id, Course course)
         {
             if (id != course.CourseId)
             {
                 return BadRequest();
             }

             _context.Entry(course).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!CourseExists(id))
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

         // POST: api/Courses
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
         public async Task<ActionResult<Course>> PostCourse(Course course)
         {
             _context.Courses.Add(course);
             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateException)
             {
                 if (CourseExists(course.CourseId))
                 {
                     return Conflict();
                 }
                 else
                 {
                     throw;
                 }
             }

             return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
         }

         // DELETE: api/Courses/5
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteCourse(int id)
         {
             var course = await _context.Courses.FindAsync(id);
             if (course == null)
             {
                 return NotFound();
             }

             _context.Courses.Remove(course);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         private bool CourseExists(int id)
         {
             return _context.Courses.Any(e => e.CourseId == id);
         }*/
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet(nameof(GetAllCourse))]
    public IActionResult GetAllCourse()
    {
        var res = _courseService.GetAllCourses();
        if (res is not null)
        {
            return Ok(res);
        }
        return BadRequest("No Record Found");
    }

    [HttpGet(nameof(GetCourse))]
    public IActionResult GetCourse(int id)
    {
        var res = _courseService.GetCourse(id);
        if (res is not null)
        {
            return Ok(res);
        }
        return BadRequest("No Record Found");
    }

    [HttpPost(nameof(InsertCourse))]
    public IActionResult InsertCourse(Course course)
    {
        _courseService.InsertCourse(course);
        return Ok("Data Saved SuccessFully");
    }


    [HttpPut(nameof(UpdateCourse))]
    public IActionResult UpdateCourse(Course course)
    {
        _courseService.UpdateCourse(course);
        return Ok("Data Updated Successfully");
    }

    [HttpDelete(nameof(DeleteCourse))]
    public IActionResult DeleteCourse(int id)
    {
        _courseService.DeleteCourse(id);
        return Ok("Data Deleted Successfully");
    }

}
}
