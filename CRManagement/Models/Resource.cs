using System;
using System.Collections.Generic;

#nullable disable

namespace CRManagement.Models
{
    public partial class Resource
    {
        public Resource()
        {
            ResourseEnquiries = new HashSet<ResourseEnquiry>();
        }

        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public int ResourcePrice { get; set; }
        public bool ResourceAvaiStatus { get; set; }

        public virtual ICollection<ResourseEnquiry> ResourseEnquiries { get; set; }
    }
}
