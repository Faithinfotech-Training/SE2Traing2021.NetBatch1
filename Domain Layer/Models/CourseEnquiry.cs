using System;
using System.Collections.Generic;
using Domain_Layer.Models;


#nullable disable

namespace Domain_Layer.Models
{
    public partial class CourseEnquiry : BaseEntity
    {

        public string CourseFullName { get; set; }
        public string CourseEmail { get; set; }
        public string CoursePhone { get; set; }
        public DateTime Dob { get; set; }
        public string Qualification { get; set; }
        public int CourseTestScore { get; set; }
        public string CourseStageStatus { get; set; }
        
        public DateTime CourseErecordDate { get; set; }
        public DateTime CourseEupdateDate { get; set; }

        public virtual Course CourseEn { get; set; }
    }
}
