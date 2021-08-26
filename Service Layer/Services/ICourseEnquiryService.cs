using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public interface ICourseEnquiryService
    {
        IEnumerable<CourseEnquiry> GetAllCourseEnquiry();
        CourseEnquiry GetCourseEnquiry(int id);

        void InsertCourse(CourseEnquiry courseenquiry);
        void UpdateCourse(CourseEnquiry courseenquiry);
        void DeleteCourse(int Id);
    }
}
