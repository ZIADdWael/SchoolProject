using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entites
{
    public class StudentSubject: GeneralLocalizableEntity
    {
        [Key]
        public int StudID { get; set; }
        [Key]
        public int SubID { get; set; }
        public decimal? grade { get; set; }

        [ForeignKey("StudID")]
        [InverseProperty("StudentSubject")]
        public virtual Student? Student { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty("StudentsSubjects")]
        public virtual Subjects? Subject { get; set; }

    }
}
