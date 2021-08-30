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
            private IRepository<resource> _repository;
            public ResourceService(IRepository<resource> repository)
            {
                _repository = repository;
            }

            public void DeletetResource(int Id)
            {
                resource resource = GetResource(Id);
                _repository.Remove(resource);
                _repository.SaveChanges();
            }

            public IEnumerable<resource> GetAllResources()
            {
                return _repository.GetAll();
            }

            public resource GetResource(int id)
            {
                return _repository.Get(id);
            }


            public void InsertResource(resource resource)
            {
                _repository.Insert(resource);
            }



            public void UpdateResource(resource resource)
            {
                _repository.Update(resource);
            }


        }
    }

