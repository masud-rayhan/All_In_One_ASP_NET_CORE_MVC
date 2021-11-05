using All_In_One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_In_One.DataAccess.Repository.IRepository
{
    public interface IStudentTeacherRepository : IRepository<StudentTeacher>
    {
        void Update(StudentTeacher studentTeacher);
    }
}
