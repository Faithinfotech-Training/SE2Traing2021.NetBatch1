using Domain_Layer.Models;
using Repository_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class ResourceService : IResourceService
    {
        private IRepository<Resource> _repository;
        public ResourceService(IRepository<Resource> repository)
        {
            _repository = repository;
        }

        public void DeletetResource(int Id)
        {
            Resource resource = GetResource(Id);
            _repository.Remove(resource);
            _repository.SaveChanges();
        }

        public IEnumerable<Resource> GetAllResources()
        {
            return _repository.GetAll();
        }

        public Resource GetResource(int id)
        {
            return _repository.Get(id);
        }

       
        public void InsertResource(Resource resource)
        {
            _repository.Insert(resource);
        }

       

        public void UpdateResource(Resource resource)
        {
            _repository.Update(resource);
        }

      
    }
}
