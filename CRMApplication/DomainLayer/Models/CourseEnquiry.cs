using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public partial class CourseEnquiry:BaseEntity
    {
        public CourseEnquiry()
        {
            Trainees = new HashSet<Trainee>();
        }

        public int CourseEnquiryId { get; set; }
        public int? CourseId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public DateTime Dob { get; set; }
        public string Qualification { get; set; }
        public int? TestScore { get; set; }
        public string EnquiryStatus { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }

    }
}
