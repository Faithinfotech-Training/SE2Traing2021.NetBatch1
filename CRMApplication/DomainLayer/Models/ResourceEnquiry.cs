using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public partial class ResourceEnquiry:BaseEntity
    {
        public int ResourceEnqId { get; set; }
        public int? ResourceId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string EnquiryStatus { get; set; }

        public virtual Resource Resource { get; set; }
    }
}
