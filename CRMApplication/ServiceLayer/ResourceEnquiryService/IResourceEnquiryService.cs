using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResourceEnquiryService
{
   public  interface IResourceEnquiryService
    {
        IEnumerable<ResourceEnquiry> GetAllResourcesEnquiry();
        ResourceEnquiry GetResourceEnquiry(int id);
        void InsertResourceEnquiry(ResourceEnquiry resource);
        void UpdateResourceEnquiry(ResourceEnquiry resource);
        void DeleteResourceEnquiry(int Id);

    }
}
