using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public interface ICourseEnquiryService
    {
        IEnumerable<courseEnquiry> GetAllCourseEnquiry();
        courseEnquiry GetCourseEnquiry(int id);

        void InsertCourseEnquiry(courseEnquiry courseenquiry);
        void UpdateCourseEnquiry(courseEnquiry courseenquiry);
        void DeleteCourseEnquriy(int Id);
        public IEnumerable<courseEnquiry> getStatusBasedEnquiries(string status);

    }
}
