using Management_System1.Models;
using Management_System1.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Management_System1.Controllers
{
        [Authorize(Roles ="instructor")]
    public class InstructorController : Controller
    {

        IDepartmentRepository DR;
        ICourseRepository CR;
        IInstructorRepository InSR;

        public InstructorController(IDepartmentRepository departmentRepository , ICourseRepository courseRepository, IInstructorRepository instructorRepository)
        {
            DR = departmentRepository;            // new DepartmentRepository();
            CR = courseRepository;// new CourseRepository();
            InSR = instructorRepository;// new InstructorRepository();
        }

        public IActionResult Index()
        {
           
      

            List<Instructor> instructors = InSR.GetAll();
            var departments = DR.GetAll();
            var courses = CR.GetAll();
            ViewData["Dept"] = departments;
            ViewData["courses"] = courses;
          
     
            return View("Index",instructors);
        }


        public IActionResult Details(int id)
        {


            Instructor instructor = InSR.GetByID(id);

            return View("Details", instructor);
        }
    }
}
