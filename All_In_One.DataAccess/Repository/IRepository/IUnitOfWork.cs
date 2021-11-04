using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_In_One.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ITeacherRepository Teacher { get; }
        IDepartmentRepository Department { get; }
        IStudentRepository Student { get; }
        void Save();

     }
}
