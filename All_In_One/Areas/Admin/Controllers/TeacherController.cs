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
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult TeacherList()
        {
            var teacher = _unitOfWork.Teacher.GetAll();
            return View(teacher);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                 _unitOfWork.Teacher.Add(teacher);
                _unitOfWork.Save();
                return RedirectToAction(nameof(TeacherList));
            }

            return View(teacher);
        }
    }
}
