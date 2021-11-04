using All_In_One.DataAccess.Repository.IRepository;
using All_In_One.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace All_In_One.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult StudentList()
        {
            var studentList = _unitOfWork.Student.GetAll();
            var deptList = _unitOfWork.Department.GetAll();

            var myModel = from s in studentList
                          join d in deptList
                          on s.DepartmentId equals d.DepartmentId

                          select new Student
                          {
                              StudentName = s.StudentName,
                              StudentMail = s.StudentMail,
                              DepartmentId = s.DepartmentId,
                              Department = d
                              
                          };
            //I Have to Replaced  this join query by Linq join query 

            return View(myModel);
        }

        public IActionResult Create()
        {
            DepartmentLoad();
            return View();
        }

        public void DepartmentLoad()
        {
            
            List<Department> deptList = new List<Department>();
            deptList = (List<Department>)_unitOfWork.Department.GetAll();

            deptList.Insert(0, new Department { DepartmentId = 0, DepartmentName = "Please Select", DepartmentChairman = "", DepartmentAddress = "" });
            ViewBag.DeptList = deptList;
            
        }


    }
}
