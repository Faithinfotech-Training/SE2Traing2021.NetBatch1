using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourse(int id);

        void InsertCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int Id);

    }
}
