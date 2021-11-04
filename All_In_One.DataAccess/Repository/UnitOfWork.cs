using All_In_One.DataAccess.Data;
using All_In_One.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_In_One.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ITeacherRepository Teacher { get; private set; }

        public IDepartmentRepository Department { get; private set; }

        public IStudentRepository Student { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Teacher = new TeacherRepository(_db);
            Department = new DepartmentRepository(_db);
            Student = new StudentRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
