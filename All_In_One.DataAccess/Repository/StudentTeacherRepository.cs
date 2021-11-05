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
    class StudentTeacherRepository : Repository<StudentTeacher>,IStudentTeacherRepository
    {
        private readonly ApplicationDbContext _db;
        public StudentTeacherRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(StudentTeacher studentTeacher)
        {
            var objFromDb = _db.StudentTeacher.FirstOrDefault(st => st.id == studentTeacher.id);
            if(objFromDb != null)
            {
                objFromDb.StudentId = studentTeacher.StudentId;
                objFromDb.TeacherId = studentTeacher.TeacherId;
            }
        }
    }
}
