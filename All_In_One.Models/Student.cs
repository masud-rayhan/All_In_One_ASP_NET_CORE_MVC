using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_In_One.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Please Enter Student Name")]
        [MaxLength(150)]
        public string StudentName { get; set; }

        [Display(Name = "Student Mail")]
        [Required(ErrorMessage = "Please Enter Student Mail")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Invalid Email Address")]
        [MaxLength(150)]
        public string StudentMail { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        //Student to Department One to Many Relation
        public Department Department { get; set; }

        //Student to Teacher Many to Many Relation
        public ICollection<Teacher>Teacher{ get; set; }
        



    }
}
