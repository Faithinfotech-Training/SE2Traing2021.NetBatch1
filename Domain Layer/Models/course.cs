using Domain_Layer.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain_Layer.Models
{
    public partial class course : BaseEntity
    {
        public course()
        {
            courseEnquiries = new HashSet<courseEnquiry>();
        }


        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public TimeSpan CourseDuration { get; set; }
        public int CoursePrice { get; set; }
        public bool CourseAvaiStatus { get; set; }
        public DateTime CourseRecordDate { get; set; }

        public virtual ICollection<courseEnquiry> courseEnquiries { get; set; }
    }
}
