using System;
using System.Collections.Generic;
using CRM_Demo.Models;


#nullable disable

namespace Domain_Layer.Models
{
    public partial class resourceEnquiry :BaseEntity
    {
      
        public string ResourceFullName { get; set; }
        public string ResourceEmail { get; set; }
        public string ResourcePhone { get; set; }
        public string ResourceStatus { get; set; }
        public DateTime ResourceErecordDate { get; set; }

        public int resourceId { get; set; }
        public virtual resource resource { get; set; }
    }
}
