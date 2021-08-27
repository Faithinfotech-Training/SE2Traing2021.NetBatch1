using Domain_Layer.Models;
using Repository_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class ResourceEnquiryService : IResourceEnquiryService
    {
        private IRepository<resourceEnquiry> _repository;
        public ResourceEnquiryService(IRepository<resourceEnquiry> repository)
        {
            _repository = repository;
        }

        public void DeleteResourceEnquiry(int Id)
        {
            resourceEnquiry resourceEnquiry = GetResourceEnquiry(Id);
            _repository.Remove(resourceEnquiry);
            _repository.SaveChanges();
        }

        public IEnumerable<resourceEnquiry> GetAllResourceEnquiry()
        {
            return _repository.GetAll();
        }

        public resourceEnquiry GetResourceEnquiry(int id)
        {
            return _repository.Get(id);
        }

        public void InsertResourceEnquiry(resourceEnquiry resourceEnquiry)
        {
            _repository.Insert(resourceEnquiry);
        }

        public void UpdateResourceEnquiry(resourceEnquiry resourceEnquiry)
        {
            _repository.Update(resourceEnquiry);
            _repository.SaveChanges();
        }
    }
}
