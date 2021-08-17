using System;
using System.Collections.Generic;

#nullable disable

namespace CRManagement.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneN { get; set; }
        public string UserPassword { get; set; }
        public int UserClaimId { get; set; }

        public virtual Claim UserClaim { get; set; }
    }
}
