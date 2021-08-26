﻿using Domain_Layer.EntityMaper;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace Repository_Layer
{
    public  class CRMdbContext : DbContext
    {
        public CRMdbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CoursesMap());
            modelBuilder.ApplyConfiguration(new ResourcesMap());
            modelBuilder.ApplyConfiguration(new ClaimsMap());
            modelBuilder.ApplyConfiguration(new CourseEnquiryMap());
            modelBuilder.ApplyConfiguration(new ResourseEnquiryMap());
            modelBuilder.ApplyConfiguration(new UserMap());


            base.OnModelCreating(modelBuilder);
        }
    }
}
