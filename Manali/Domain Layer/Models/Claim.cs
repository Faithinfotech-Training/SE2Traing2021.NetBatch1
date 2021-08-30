using Domain_Layer.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace CRM_Demo.Models
{
    public partial class Claim:BaseEntity
    {
        public Claim()
        {
            Users = new HashSet<User>();
        }


        public string ClaimType { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
