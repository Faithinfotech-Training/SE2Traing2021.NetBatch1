using DomainLayer.EntityMaper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
     public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMap());
            modelBuilder.ApplyConfiguration(new ResourceMap());
            modelBuilder.ApplyConfiguration(new CourseEnquiryMap());
            modelBuilder.ApplyConfiguration(new ResourceEnquiryMap());
            modelBuilder.ApplyConfiguration(new TraineeMap());
            modelBuilder.ApplyConfiguration(new BatchMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
