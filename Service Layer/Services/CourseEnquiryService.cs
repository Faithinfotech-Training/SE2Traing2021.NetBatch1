using Domain_Layer.Models;
using Repository_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
   public class CourseEnquiryService : ICourseEnquiryService
    {
        private IRepository<courseEnquiry> _repository;
        public  CourseEnquiryService(IRepository<courseEnquiry> repository)
        {
            _repository = repository;
        }

        public void DeleteCourseEnquriy(int Id)
        {
            courseEnquiry courseenquiry = GetCourseEnquiry(Id);
            _repository.Remove(courseenquiry);
            _repository.SaveChanges();
        }

        public IEnumerable<courseEnquiry> GetAllCourseEnquiry()
        {
           return _repository.GetAll();
        }

        public courseEnquiry GetCourseEnquiry(int id)
        {
            return _repository.Get(id);
        }

        public void InsertCourseEnquiry(courseEnquiry courseenquiry)
        {
             _repository.Insert(courseenquiry);
        }

        public void UpdateCourseEnquiry(courseEnquiry courseenquiry)
        {
            _repository.Update(courseenquiry);
            _repository.SaveChanges();
        }
    }
}
