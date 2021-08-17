using System;
using System.Collections.Generic;

#nullable disable

namespace CRManagement.Models
{
    public partial class ResourseEnquiry
    {
        public int ResourceEnquiryId { get; set; }
        public string ResourceFullName { get; set; }
        public string ResourceEmail { get; set; }
        public string ResourcePhone { get; set; }
        public bool ResourceStatus { get; set; }
        public int ResourceEnId { get; set; }

        public virtual Resource ResourceEn { get; set; }
    }
}
