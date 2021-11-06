using All_In_One.DataAccess.Repository.IRepository;
using All_In_One.Models;
using All_In_One.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace All_In_One.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
                              StudentId=s.StudentId,
                              StudentName = s.StudentName,
                              StudentMail = s.StudentMail,
                              DepartmentId = s.DepartmentId,
                              Department = d
                              
                          };
            //I Have to Replaced  this join query by Linq join query 

            return View(myModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var item = _unitOfWork.Teacher.GetAll();
            StudentTeacherViewModel m1 = new StudentTeacherViewModel();
            m1.AvailableTeacher = item.Select(vm => new CheckBoxItem()
            {
                TeacherId = vm.TeacherId,
                TeacherName = vm.TeacherName,
                IsChecked = false
            }).ToList(); 
            
            DepartmentLoad();
            return View(m1);
        }

        public void DepartmentLoad()
        {
            
            List<Department> deptList = new List<Department>();
            deptList = (List<Department>)_unitOfWork.Department.GetAll();

            deptList.Insert(0, new Department { DepartmentId = 0, DepartmentName = "Please Select", DepartmentChairman = "", DepartmentAddress = "" });
            ViewBag.DeptList = deptList;
            
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Student student )
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Student.Add(student);
        //        _unitOfWork.Save();
        //    }

        //    return RedirectToAction(nameof(StudentList));
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentTeacherViewModel STM, Student student,StudentTeacher st)
        {
            List<StudentTeacher> stc = new List<StudentTeacher>();
            student.StudentName = STM.StudentName;
            student.StudentMail = STM.StudentMail;
            student.DepartmentId = STM.DepartmentId;

            _unitOfWork.Student.Add(student);
            _unitOfWork.Save();

            int stdId = student.StudentId;


            foreach(var item in STM.AvailableTeacher)
            {
                if (item.IsChecked == true)
                {
                    stc.Add(new StudentTeacher() { StudentId= stdId,TeacherId=item.TeacherId });
                }
            }

            foreach(var item in stc)
            {
                _unitOfWork.StudentTeacher.Add(item);
                _unitOfWork.Save();
            }


            return RedirectToAction(nameof(StudentList));
        }

















        public IActionResult Edit(int id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var student = _unitOfWork.Student.Get(id);





            if (student == null)
            {
                return NotFound();
            }




            List<Department> deptList = new List<Department>();
            deptList = (List<Department>)_unitOfWork.Department.GetAll();

            deptList.Insert(0, new Department { DepartmentId = 0, DepartmentName = student.Department.DepartmentName, DepartmentChairman = "", DepartmentAddress = "" });
            ViewBag.DeptList = deptList;



            

            return View(student);
        }









        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Update(student);
            }

            return RedirectToAction(nameof(StudentList));
        }


        public IActionResult Delete(int id)
        {
            {
                if (id == null || id <= 0)
                {
                    return BadRequest();
                }
                var student = _unitOfWork.Student.Get(id);

                if (student == null)
                {
                    return NotFound();
                }

                _unitOfWork.Student.Remove(student);
                _unitOfWork.Save();

                return RedirectToAction(nameof(StudentList));
            }
        }
    }
}
