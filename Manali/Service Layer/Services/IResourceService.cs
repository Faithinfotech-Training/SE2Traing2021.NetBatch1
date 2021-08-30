using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public interface IResourceService
    {
        IEnumerable<resource> GetAllResources();
        resource GetResource(int id);

        void InsertResource(resource resource);
        void UpdateResource(resource resource);
        void DeletetResource(int Id);

    }
}
