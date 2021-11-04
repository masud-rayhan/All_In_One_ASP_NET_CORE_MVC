using All_In_One.DataAccess.Data;
using All_In_One.DataAccess.Repository.IRepository;
using All_In_One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_In_One.DataAccess.Repository
{
    public class StudentRepository: Repository<Student> , IStudentRepository
    {
        private readonly ApplicationDbContext _db;

        public StudentRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(Student student)
        {
            var obj = _db.Students.FirstOrDefault(x => x.StudentId == student.StudentId);
            
            if(obj != null)
            {
                obj.StudentName = student.StudentName;
                obj.StudentMail = student.StudentMail;
                obj.DepartmentId = student.DepartmentId;
                _db.SaveChanges();
            }

        }


        
    }
}
