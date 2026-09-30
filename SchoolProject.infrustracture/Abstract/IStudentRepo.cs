using SchoolProject.Data.Entites;
using SchoolProject.infrustracture.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infrustracture.Abstract
{
    public interface IStudentRepo:IGenericRepositoryAsync<Student>
    {
        public  Task<List<Student>> GetAllStudentsAsync();
        //public  Task<Student> GetStudentByIDAsyncRepo(int id);

    }
}
