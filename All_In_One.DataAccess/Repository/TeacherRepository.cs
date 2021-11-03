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
     public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private readonly ApplicationDbContext _db;

        public TeacherRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(Teacher teacher)
        {
            var obj = _db.Teachers.FirstOrDefault(s=>s.TeacherId==teacher.TeacherId);
            if(obj != null)
            {
                obj.TeacherName = teacher.TeacherName;
                obj.TeacherMail = teacher.TeacherMail;
                obj.SubjectOfTeacher = teacher.SubjectOfTeacher;

                _db.SaveChanges();
            }
        }
    }
}
