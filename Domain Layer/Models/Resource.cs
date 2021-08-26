using CRM_Demo.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain_Layer.Models
{
    public partial class Resource : BaseEntity
    {
        public Resource()
        {
            ResourseEnquiries = new HashSet<ResourseEnquiry>();
        }

        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public int ResourcePrice { get; set; }
        public bool ResourceAvaiStatus { get; set; }
        public string ResourceType { get; set; }
        public DateTime ResourceRecordDate { get; set; }
        public DateTime ResourceUpdateDate { get; set; }

        public virtual ICollection<ResourseEnquiry> ResourseEnquiries { get; set; }
    }
}
