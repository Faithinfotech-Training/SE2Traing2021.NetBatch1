using System;
using System.Collections.Generic;
using CRM_Demo.Models;


#nullable disable

namespace Domain_Layer.Models
{
    public partial class ResourseEnquiry :BaseEntity
    {
        public string ResourceFullName { get; set; }
        public string ResourceEmail { get; set; }
        public string ResourcePhone { get; set; }
        public bool ResourceStatus { get; set; }
        public DateTime ResourceErecordDate { get; set; }
        public DateTime ResourceEupdateDate { get; set; }

        public virtual Resource ResourceEn { get; set; }
    }
}
