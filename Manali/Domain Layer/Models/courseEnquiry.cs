using System;
using System.Collections.Generic;
using Domain_Layer.Models;


#nullable disable

namespace Domain_Layer.Models
{
    public partial class courseEnquiry : BaseEntity
    {
      /*  public courseEnquiry()
        {
            course = new HashSet<course>();
        }*/
        public string CourseFullName { get; set; }
        public string CourseEmail { get; set; }
        public string CoursePhone { get; set; }
        public DateTime Dob { get; set; }
        public string Qualification { get; set; }
        public int CourseTestScore { get; set; }
        public string CourseStageStatus { get; set; }
        
        public DateTime CourseErecordDate { get; set; }

        public int? courseId { get; set; }
       
        public virtual course course { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }

    }
}
