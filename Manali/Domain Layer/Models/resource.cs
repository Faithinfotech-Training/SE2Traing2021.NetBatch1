using CRM_Demo.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain_Layer.Models
{
    public partial class resource : BaseEntity
    {
        public resource()
        {
            resourceEnquiries = new HashSet<resourceEnquiry>();
        }

        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public int ResourcePrice { get; set; }
        public bool ResourceAvaiStatus { get; set; }
        public string ResourceType { get; set; }
        public DateTime ResourceRecordDate { get; set; }

        public virtual ICollection<resourceEnquiry> resourceEnquiries { get; set; }
    }
}
