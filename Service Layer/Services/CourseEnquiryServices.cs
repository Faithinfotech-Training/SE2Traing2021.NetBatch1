using Domain_Layer.Models;
using Repository_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
   public class CourseEnquiryServices : ICourseEnquiryService
    {
        private IRepository<CourseEnquiry> _repository;
        public  CourseEnquiryServices(IRepository<CourseEnquiry> repository)
        {
            _repository = repository;
        }

        public void DeleteCourse(int Id)
        {
            CourseEnquiry courseenquiry = GetCourseEnquiry(Id);
            _repository.Remove(courseenquiry);
            _repository.SaveChanges();
        }

        public IEnumerable<CourseEnquiry> GetAllCourseEnquiry()
        {
           return _repository.GetAll();
        }

        public CourseEnquiry GetCourseEnquiry(int id)
        {
            return _repository.Get(id);
        }

        public void InsertCourse(CourseEnquiry courseenquiry)
        {
             _repository.Insert(courseenquiry);
        }

        public void UpdateCourse(CourseEnquiry courseenquiry)
        {
            _repository.Update(courseenquiry);
            _repository.SaveChanges();
        }
    }
}
