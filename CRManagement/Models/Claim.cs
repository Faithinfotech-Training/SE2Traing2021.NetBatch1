using System;
using System.Collections.Generic;

#nullable disable

namespace CRManagement.Models
{
    public partial class Claim
    {
        public Claim()
        {
            Users = new HashSet<User>();
        }

        public int ClaimId { get; set; }
        public string ClaimType { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
