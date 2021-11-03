using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_In_One.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Display(Name = "Teacher Name")]
        [Required(ErrorMessage = "Please Enter Teacher Name")]
        [MaxLength(150)]
        public string TeacherName { get; set; }

        [Display(Name = "Teacher's Subject")]
        [Required(ErrorMessage = "Please Enter Sunject Name")]
        [MaxLength(150)]
        public string SubjectOfTeacher { get; set; }


        [Display(Name = "Teacher Mail")]
        [Required(ErrorMessage = "Please Enter Teacher Mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        [MaxLength(150)]
        public string TeacherMail { get; set; }


        public ICollection<Student>Student { get; set; }
    }
}
