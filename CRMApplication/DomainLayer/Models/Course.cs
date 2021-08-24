using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public partial class Course:BaseEntity
    {
        public Course()
        {
            Batches = new HashSet<Batch>();
            CourseEnquiries = new HashSet<CourseEnquiry>();
        }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDesc { get; set; }
        public int CourseDuration { get; set; }
        public decimal CoursePrice { get; set; }
        public bool  CourseAvailability { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
        public virtual ICollection<CourseEnquiry> CourseEnquiries { get; set; }
    }
}
