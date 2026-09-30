using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entites
{
    public class Department : GeneralLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
            Instructors = new HashSet<Instructor>();
        }

        [Key]
        public int DID { get; set; }

        [StringLength(500)]
        public string? DNameEn { get; set; }

        public string? DNameAr { get; set; }

        public int? InsManager { get; set; }

        [InverseProperty(nameof(Student.Department))]
        public virtual ICollection<Student> Students { get; set; }

        [InverseProperty(nameof(DepartmetSubject.Department))]
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }

        [InverseProperty(nameof(Instructor.department))]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [ForeignKey(nameof(InsManager))]
        [InverseProperty(nameof(Instructor.departmentManager))]
        public virtual Instructor? Instructor { get; set; }
    }
}