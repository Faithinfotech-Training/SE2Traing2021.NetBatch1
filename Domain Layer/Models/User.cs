using CRM_Demo.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain_Layer.Models
{
    public partial class User : BaseEntity
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneN { get; set; }
        public string UserPassword { get; set; }
        public DateTime UserRecordDate { get; set; }
        public DateTime UserUpdateDate { get; set; }

        public virtual Claim UserClaim { get; set; }
    }
}
