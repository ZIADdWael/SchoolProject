using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entites;

namespace SchoolProject.infrustracture.Configraution
{
    public class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder
               .HasOne(x => x.Supervisor)
               .WithMany(x => x.Instructors)
               .HasForeignKey(x => x.SupervisorId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
