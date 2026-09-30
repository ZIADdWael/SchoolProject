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
    public class SubjectRepo:GenericRepositoryAsync<Subjects>,ISubjectRepo
    {
        private DbSet<Subjects> _subjects;
        public SubjectRepo(AppDbContext dbContext):base(dbContext)
        {
            _subjects=dbContext.Set<Subjects>();
        }
    }
}
