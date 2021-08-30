using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
    public partial class Batch:BaseEntity
    {
        public int BatchId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public int? CourseId { get; set; }

        public virtual course course { get; set; }
    }
}
