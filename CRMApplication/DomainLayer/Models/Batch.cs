using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public partial class Batch : BaseEntity
    {
        public int BatchId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
