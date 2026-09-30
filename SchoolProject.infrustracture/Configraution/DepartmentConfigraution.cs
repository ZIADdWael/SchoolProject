using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infrustracture.Configraution
{
    public class DepartmentConfigraution:IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> modelBuilder) {


            modelBuilder.HasMany(x => x.Students).WithOne(d => d.Department).
                HasForeignKey(f => f.DID).
                OnDelete(DeleteBehavior.Restrict);

            modelBuilder.HasKey(x => x.DID);

            modelBuilder.HasOne(x => x.Instructor).
                WithOne(x => x.departmentManager)
                .HasForeignKey<Department>(x => x.InsManager)
               .OnDelete(DeleteBehavior.Restrict);
        



        }

    }
}
