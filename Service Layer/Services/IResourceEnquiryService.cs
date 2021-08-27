using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public interface IResourceEnquiryService
    {
        IEnumerable<resourceEnquiry> GetAllResourceEnquiry();
        resourceEnquiry GetResourceEnquiry(int id);

        void InsertResourceEnquiry(resourceEnquiry resource);
        void UpdateResourceEnquiry(resourceEnquiry resource);
        void DeleteResourceEnquiry(int Id);

    }
}
