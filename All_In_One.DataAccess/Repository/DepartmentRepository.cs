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
    public class DepartmentRepository: Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;

        public DepartmentRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(Department department)
        {
            var obj = _db.Departments.FirstOrDefault(x => x.DepartmentId == department.DepartmentId);

            if(obj != null)
            {
                obj.DepartmentName = department.DepartmentName;
                obj.DepartmentChairman = department.DepartmentChairman;
                obj.DepartmentAddress = department.DepartmentAddress;

                _db.SaveChanges();
            }
        }
    }
}
