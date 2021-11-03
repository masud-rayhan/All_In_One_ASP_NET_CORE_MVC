using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_In_One.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Please Enter Department Name")]
        [MaxLength(150)]
        public string DepartmentName { get; set; }


        [Display(Name = "Chairman")]
        [Required(ErrorMessage = "Please Enter Chairman Name")]
        [MaxLength(150)]
        public string DepartmentChairman { get; set; }

        [Display(Name = "Addresss")]
        [Required(ErrorMessage = "Please Enter Department Address")]
        [MaxLength(150)]
        public string DepartmentAddress { get; set; }


        public ICollection<Student>Student { get; set; }
    }
}
