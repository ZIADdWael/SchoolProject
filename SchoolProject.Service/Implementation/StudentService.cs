using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Data.Helper;
using SchoolProject.infrustracture.Abstract;
using SchoolProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementation
{
    internal class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepo _studentRepo;
        #endregion

        #region Constructor
        public StudentService(IStudentRepo studentRepo)
        {
            this._studentRepo = studentRepo;
        }

       
        #endregion

        #region Handle Function
        public async Task<List<Student>> GetStudentsAsync()
        {
           return await _studentRepo.GetAllStudentsAsync();
        }
        public async Task<Student> GetStudentByIDAsync(int id)
        {
           var std=  _studentRepo.GetTableNoTracking().Include(x=>x.Department).Where(x=>x.StudID==id).FirstOrDefault();
            return std;
        }

        public async Task<string> AddAsync(Student student)
        {
           
            //if (Std.StudID != null)
            //{
            //    Std.StudID = null;
            
            await  _studentRepo.AddAsync(student);
            return "Success";

        }

        public async Task<bool> IsNameExist(string name)
        {
            var Std = _studentRepo.GetTableNoTracking().Where(x => x.NameEn.Equals(name)).FirstOrDefault();
            if (Std == null)
            {

                return false;

            }
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            var Std = await _studentRepo.GetTableNoTracking().Where(x => x.NameEn.Equals(name)&!x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (Std == null)
            {

                return false;

            }
            return true;
        }
        public async Task<bool> IsNameArExist(string nameAr)
        {
            //Check if the name is Exist Or not
            var student = _studentRepo.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }
        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {
            //Check if the name is Exist Or not
            var student = await _studentRepo.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }
        public async Task<bool> IsNameEnExist(string nameEn)
        {
            //Check if the name is Exist Or not
            var student = _studentRepo.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }
        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            //Check if the name is Exist Or not
            var student = await _studentRepo.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<string> EditAsync(Student student)
        {
           await _studentRepo.UpdateAsync(student);
            return "Success"; 
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans =  _studentRepo.BeginTransaction();
            try
            {
                await _studentRepo.DeleteAsync(student);
              await  trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
           
        }

        public Task<Student> GetByIDWithoutIncludeAsync(int id)
        {
            var std = _studentRepo.GetByIdAsync(id);
            return std;
        }

        public IQueryable<Student> GetStudentsQuerable()
        {
            return _studentRepo.GetTableNoTracking().Include(x=>x.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum , string search)
        {
            var querable= _studentRepo.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => x.NameEn.Contains(search) || x.Address.Contains(search));
            }
            switch (orderingEnum)
            {
                case StudentOrderingEnum.StudID:
                    querable = querable.OrderBy(x => x.StudID);
                    break;
                case StudentOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.NameEn);
                    break;
                case StudentOrderingEnum.Address:
                    querable = querable.OrderBy(x => x.Address);
                    break;
                case StudentOrderingEnum.DepartName:
                    querable = querable.OrderBy(x => x.Department.DNameEn);
                    break;

            }

            return querable;
        }

        public IQueryable<Student> GetStudentsByDepartmentIDQuerable(int DID)
        {
            return _studentRepo.GetTableNoTracking().Where(x=>x.DID.Equals(DID)).AsQueryable();
        }
        #endregion


    }
}
