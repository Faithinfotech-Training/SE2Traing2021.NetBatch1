using System;
using System.Collections.Generic;

#nullable disable

namespace CRManagement.Models
{
    public partial class CourseEnquiry
    {
        public int CourseEnquiryId { get; set; }
        public string CourseFullName { get; set; }
        public string CourseEmail { get; set; }
        public string CoursePhone { get; set; }
        public DateTime Dob { get; set; }
        public string Qualification { get; set; }
        public int CourseTestScore { get; set; }
        public string CourseStageStatus { get; set; }
        public int CourseEnId { get; set; }

        public virtual Course CourseEn { get; set; }
    }
}
