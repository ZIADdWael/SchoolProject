using SchoolProject.Data.Entites;
using SchoolProject.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstract
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentByIDAsync(int id);
        public Task<Student> GetByIDWithoutIncludeAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(string name,int id);

        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        public IQueryable<Student> GetStudentsQuerable();
        public IQueryable<Student> GetStudentsByDepartmentIDQuerable(int DID);
        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public  Task<bool> IsNameEnExist(string nameEn);
        public  Task<bool> IsNameArExist(string nameAr);




    }
}
