using Domain_Layer.Models;
using Repository_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class ResourseEnquiryService : IResourseEnquiry
    {
        private IRepository<ResourseEnquiry> _repository;
        public ResourseEnquiryService(IRepository<ResourseEnquiry> repository)
        {
            _repository = repository;
        }

        public void DeleteCourse(int Id)
        {
            ResourseEnquiry courseenquiry = GetCourseEnquiry(Id);
            _repository.Remove(courseenquiry);
            _repository.SaveChanges();
        }

        public IEnumerable<ResourseEnquiry> GetAllCourseEnquiry()
        {
            return _repository.GetAll();
        }

        public ResourseEnquiry GetCourseEnquiry(int id)
        {
            return _repository.Get(id);
        }

        public void InsertCourse(ResourseEnquiry courseenquiry)
        {
            _repository.Insert(courseenquiry);
        }

        public void UpdateCourse(ResourseEnquiry courseenquiry)
        {
            _repository.Update(courseenquiry);
            _repository.SaveChanges();
        }
    }
}
