using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResourceService
{
    public interface IResourceService
    {
        IEnumerable<Resource> GetAllResources();
        Resource GetResource(int id);

        void InsertResource(Resource resource);
        void UpdateResource(Resource resource);
        void DeletetResource(int Id);
    }
}
