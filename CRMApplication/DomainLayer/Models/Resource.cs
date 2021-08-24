using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public partial class Resource:BaseEntity
    {
        public Resource()
        {
            ResourceEnquiries = new HashSet<ResourceEnquiry>();

        }
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceDesc { get; set; }
        public decimal ResourcePrice { get; set; }        
        public string Type { get; set; }
        public bool Visibility { get; set; }

        public virtual ICollection<ResourceEnquiry> ResourceEnquiries { get; set; }

    }
}
