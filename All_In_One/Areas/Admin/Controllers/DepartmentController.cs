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
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult DepartmentList()
        {
            var deptList = _unitOfWork.Department.GetAll();
            return View(deptList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Department.Add(department);
                _unitOfWork.Save();
            }

            return RedirectToAction(nameof(DepartmentList));
        }


        public IActionResult Edit(int id)
        {
            if(id==null || id <= 0)
            {
                return BadRequest();
            }
            var department = _unitOfWork.Department.Get(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Department.Update(department);
            }

            return RedirectToAction(nameof(DepartmentList));
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var department = _unitOfWork.Department.Get(id);

            if (department == null)
            {
                return NotFound();
            }

            _unitOfWork.Department.Remove(department);
            _unitOfWork.Save();

            return RedirectToAction(nameof(DepartmentList));
        }






    }
}
