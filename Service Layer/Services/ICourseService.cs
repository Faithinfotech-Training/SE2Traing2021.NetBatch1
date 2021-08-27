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
        IEnumerable<course> GetAllCourses();
        course GetCourse(int id);

        void InsertCourse(course course);
        void UpdateCourse(course course);
        void DeleteCourse(int Id);

    }
}
