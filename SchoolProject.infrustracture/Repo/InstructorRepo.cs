using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.infrustracture.Abstract;
using SchoolProject.infrustracture.DataBase;
using SchoolProject.infrustracture.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infrustracture.Repo
{
    public class InstructorRepo:GenericRepositoryAsync<Instructor>,IinstructorRepo
    {
        private DbSet<Instructor> _instructorRepo;
        public InstructorRepo(AppDbContext dbContext) : base(dbContext)
        {

            _instructorRepo  = dbContext.Set<Instructor>();

        }
    }

}
