using DomainLayer.Models;
using RepositoryLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResourceEnquiryService
{
    public class ResourceEnquiryService : IResourceEnquiryService
    {
        private IRepository<ResourceEnquiry> _repository;
        public ResourceEnquiryService(IRepository<ResourceEnquiry> repository)
        {
            _repository = repository;
        }

        public void DeleteResourceEnquiry(int Id)
        {
            ResourceEnquiry course = GetResourceEnquiry(Id);
            _repository.Remove(course);
            _repository.SaveChanges();
        }

        public IEnumerable<ResourceEnquiry> GetAllResourcesEnquiry()
        {
            return _repository.GetAll();
        }

        public ResourceEnquiry GetResourceEnquiry(int id)
        {

            return _repository.Get(id);
        }

        public void InsertResourceEnquiry(ResourceEnquiry resource)
        {
            _repository.Insert(resource);
        }

        public void UpdateResourceEnquiry(ResourceEnquiry resource)
        {
            _repository.Update(resource);
        }
    }
}