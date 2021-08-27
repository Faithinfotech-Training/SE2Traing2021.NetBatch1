using Domain_Layer.Models;
using Repository_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class CourseService : ICourseService
    {
        private IRepository<course> _repository;
        public CourseService(IRepository<course> repository)
        {
            _repository = repository;
        }
        public void DeleteCourse(int Id)
        {
            course course = GetCourse(Id);
            _repository.Remove(course);
            _repository.SaveChanges();
        }

        public IEnumerable<course> GetAllCourses()
        {
            return _repository.GetAll();
        }

        public course GetCourse(int id)
        {
            return _repository.Get(id);
        }

        public void InsertCourse(course course)
        {
            _repository.Insert(course);
        }

        public void UpdateCourse(course course)
        {
            _repository.Update(course);

        }
    }
}
