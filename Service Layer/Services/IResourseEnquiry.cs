using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public interface IResourseEnquiry
    {
        IEnumerable<ResourseEnquiry> GetAllCourseEnquiry();
        ResourseEnquiry GetCourseEnquiry(int id);

        void InsertCourse(ResourseEnquiry courseenquiry);
        void UpdateCourse(ResourseEnquiry courseenquiry);
        void DeleteCourse(int Id);
    }
}
