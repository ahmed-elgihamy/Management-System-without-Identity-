using Management_System1.Models;
using Management_System1.Repository;
using Management_System1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Security.Claims;

namespace Management_System1.Controllers
{
              // admain or instructor
    [Authorize(Roles = "admain")]
    //[Authorize(Roles = "instructor ")]

  
    public class TraineeController : Controller
    {
        DataShowTrainee DST;
        IDepartmentRepository _departmentRepository;
        IStudentRepository _studentRepository;

        public TraineeController(IStudentRepository studentRepository,  IDepartmentRepository departmentRepository)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
            DST = new DataShowTrainee();
        }


      //    [Authorize(Roles ="Student")] //must be role admain and student
          // [AllowAnonymous]
        public IActionResult Index()
        {
         var   trainees = _studentRepository.GetAll();
         var   depts = _departmentRepository.GetAll();
         DST = new DataShowTrainee();

            DST.trainees = trainees;
            DST.Depts = depts;
          

            return View(DST);
        }

        [HttpGet]
   //     [Authorize(Roles = "Admain")]
        public IActionResult CreateStudent()
        {
            var depts = _departmentRepository.GetAll();
            ViewBag.Depts = depts;

            return View();
        }

        [HttpPost]
       // [Authorize(Roles = "Admain")]
        public IActionResult CreateStudent(Trainee trainee)
        {

            if(ModelState.IsValid)
            {
                if (trainee.Dept_Id != 0)
                {

                    _studentRepository.Add(trainee);

                    return RedirectToAction("index");
                }
                else
                {
                    ModelState.AddModelError("Dept_Id", "plz Select Department");
                }
            }

            ViewBag.depts = _departmentRepository.GetAll();
            return View("CreateStudent", trainee);
        }

        public IActionResult Edit(int ?id)
        {
            if (id == null)
                return BadRequest();
            var s = _studentRepository.GetByID(id);
            if (s == null)
                return NotFound();
            ViewBag.depts = _departmentRepository.GetAll();
            return View(s);
        }
        [HttpPost]
        public IActionResult Edit(Trainee trainee)
        {

            if (ModelState.IsValid)
            {
                _studentRepository.Edit(trainee.Id, trainee);
                return RedirectToAction("index");
            }
            ViewBag.depts = _departmentRepository.GetAll();

            return View("edit", trainee);
        }

        public IActionResult Delete(int id)
        {
            //dBContext.Trainees.Where(d => d.Id == id).ExecuteDelete();
            _studentRepository.Delete(id);
            return RedirectToAction("index");
        }

     //   [Authorize(Roles = "Admain")]
        public IActionResult Details (int id)
        {
            var std = _studentRepository.GetByID(id);

            return View("Details", std);
        }
    }
}
