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
    public class StudentTeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentTeacherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult StudentTeacherList()
        {
            var studentTeacherList = _unitOfWork.StudentTeacher.GetAll();
            var studentList = _unitOfWork.Student.GetAll();
            var teacherList = _unitOfWork.Teacher.GetAll();

            var myModel = from st in studentTeacherList
                          join s in studentList on st.StudentId equals s.StudentId
                          join t in teacherList on st.TeacherId equals t.TeacherId

                          select new StudentTeacher
                          {
                              id=st.id,
                              StudentId = st.StudentId,
                              TeacherId = st.TeacherId,
                              Student = s,
                              Teacher = t
                          };


            //join Query should be Replaced by Linq join 

            return View(myModel);
        }



        public void StudentLoad()
        {

            List<Student> studentList = new List<Student>();
            studentList = (List<Student>)_unitOfWork.Student.GetAll();

            studentList.Insert(0, new Student { StudentId = 0, StudentName = "Please Select", StudentMail = "" });
            ViewBag.StuList = studentList;

        }

        public void TeacherLoad()
        {
            List<Teacher> teacherList = new List<Teacher>();
            teacherList = (List<Teacher>)_unitOfWork.Teacher.GetAll();
            teacherList.Insert(0, new Teacher {TeacherId=0,TeacherName="Please Select",SubjectOfTeacher="" });
            ViewBag.TeacherList = teacherList;
        }




        public IActionResult Create()
        {
            StudentLoad();
            TeacherLoad();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentTeacher studentTeacher)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.StudentTeacher.Add(studentTeacher);
                _unitOfWork.Save();
                return RedirectToAction(nameof(StudentTeacherList));
            }
            return View(studentTeacher);
        }



        public IActionResult Edit(int id)
        {
            if(id==null || id <= 0)
            {
                return BadRequest();
            }
            var studentTeacher = _unitOfWork.StudentTeacher.Get(id);
            
            if(studentTeacher == null)
            {
                return NotFound();
            }

            List<Student> studentList = new List<Student>();
            studentList = (List<Student>)_unitOfWork.Student.GetAll();
            studentList.Insert(0, new Student { StudentId = studentTeacher.StudentId, StudentName = studentTeacher.Student.StudentName, StudentMail = "" });
            ViewBag.StuList = studentList;




            List<Teacher> teacherList = new List<Teacher>();
            teacherList = (List<Teacher>)_unitOfWork.Teacher.GetAll();
            teacherList.Insert(0, new Teacher { TeacherId = studentTeacher.TeacherId, TeacherName = studentTeacher.Teacher.TeacherName, SubjectOfTeacher = "" });
            ViewBag.TeacherList = teacherList;


            return View(studentTeacher);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentTeacher studentTeacher)
        {
            if (ModelState.IsValid)
            {
                var objFromDb = _unitOfWork.StudentTeacher.GetFirstOrDefault(s => s.id == studentTeacher.id);
                
                if(objFromDb != null)
                {
                    objFromDb.id = studentTeacher.id;
                    objFromDb.StudentId = studentTeacher.StudentId;
                    objFromDb.TeacherId = studentTeacher.TeacherId;

                }
                _unitOfWork.Save();
            }

            return RedirectToAction(nameof(StudentTeacherList));
        }

        public IActionResult Delete(int id)
        {
            if(id==null || id <= 0)
            {
                return BadRequest();
            }
            var studentTeacher = _unitOfWork.StudentTeacher.Get(id);

            _unitOfWork.StudentTeacher.Remove(studentTeacher);
            _unitOfWork.Save();

            return RedirectToAction(nameof(StudentTeacherList));

        }


    }
}
