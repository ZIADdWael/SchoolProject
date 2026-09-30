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
    public class StudentRepo : GenericRepositoryAsync<Student>,IStudentRepo
    {
        #region Fields
        private readonly DbSet<Student>_studentsRepo;

        #endregion

        #region Constructor
        public StudentRepo(AppDbContext appDbContext):base(appDbContext) 
        {
            _studentsRepo =   appDbContext.Set<Student>();
        }
        #endregion

        #region Handle Functions
        public async Task<List<Student>> GetAllStudentsAsync()
        {

            return await _studentsRepo.Include(x=>x.Department).ToListAsync();
        }

        //public async Task<Student> GetStudentByIDAsyncRepo(int id)
        //{
        //   return await _dbContext.Students.FirstOrDefaultAsync(x=>x.StudID==id);
        //}
        #endregion

    }
}
