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
        private IRepository<Course> _repository;
        public CourseService(IRepository<Course> repository)
        {
            _repository = repository;
        }
        public void DeleteCourse(int Id)
        {
            Course course = GetCourse(Id);
            _repository.Remove(course);
            _repository.SaveChanges();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _repository.GetAll();
        }

        public Course GetCourse(int id)
        {
            return _repository.Get(id);
        }

        public void InsertCourse(Course course)
        {
            _repository.Insert(course);
        }

        public void UpdateCourse(Course course)
        {
            _repository.Update(course);
        }
    }
}
