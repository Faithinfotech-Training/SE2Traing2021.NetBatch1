using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
        public partial class Trainee:BaseEntity
        {
            public int TraineeId { get; set; }
            public int? BatchId { get; set; }
            public int? CourseEnqId { get; set; }
            /*public Trainee(int? batchId, int courseEnquiryId)
            {
                BatchId = batchId;
                CourseEnqId = courseEnquiryId;
            }*/
            public virtual courseEnquiry CourseEnq { get; set; }
        }
   
}
