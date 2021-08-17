using System;
using System.Collections.Generic;

#nullable disable

namespace CRManagement.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseEnquiries = new HashSet<CourseEnquiry>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public TimeSpan CourseDuration { get; set; }
        public int CoursePrice { get; set; }
        public bool CourseAvaiStatus { get; set; }

        public virtual ICollection<CourseEnquiry> CourseEnquiries { get; set; }
    }
}
