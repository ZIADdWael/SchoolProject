using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.infrustracture.Abstract;
using SchoolProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementation
{
    internal class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo _departmentRepo;

        public DepartmentService(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }
        public Task<Department> GetDepartmentByID(int id)
        {
            var res=_departmentRepo.GetTableNoTracking().Where(x=>x.DID.Equals(id))
                .Include(x=>x.DepartmentSubjects).ThenInclude(x=>x.Subject  )
                .Include(x=>x.Instructors).Include(x=>x.Instructor).
                FirstOrDefaultAsync();

            return res;
        }
    }
}
