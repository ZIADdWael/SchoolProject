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
    public class DepartmentRepo : GenericRepositoryAsync<Department>, IDepartmentRepo
    {
        private DbSet<Department> _departmentRepo;
        public DepartmentRepo(AppDbContext dbContext) : base(dbContext)
        {
            
                _departmentRepo = dbContext.Set<Department>();
            
        }
    }
}
