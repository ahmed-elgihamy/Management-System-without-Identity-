using Management_System1.Models;
using Management_System1.Repository;
using Management_System1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace Management_System1.Controllers
{

    
    [Authorize(Roles = "admain")]
    public class CourseController : Controller
    {
      
        ICourseRepository CR;
        IStudentRepository SR;
        ICourseResultRepository CRR;
        public CourseController(ICourseRepository courseRepository , IStudentRepository studentRepository , ICourseResultRepository courseResultRepository)
        {

            CR = courseRepository;        //new CourseRepository();
            SR = studentRepository;                       //new StudentRepository();
            CRR = courseResultRepository;       //new CourseResultRepository();
        }
        public IActionResult Index()
        {

            var courses = CR.GetAll();

            return View("index",courses);
        }


        public IActionResult GetResultById(int id)
        {
            
            Trainee trainee = SR.GetByID(id);
            if (trainee == null)
            {
               
                return View("index");
            }


            CourseResult CResult = CRR.GetByID(id);
                
            if (CResult == null)
            {
                
                return View("index");
            }


            Course? course = CR.GetByID(CResult.Id);
            if (course == null)
            {
                
                return View("index");
            }

            
            DataOfCourse DOC = new DataOfCourse
            {
                Id = trainee.Id,
                Degree = CResult.Degree,
                Name = trainee.Name,
                CourseName = course.Name
            };

           
            if (CResult.Degree >= course.MinDegree)
            {
                DOC.sucessOrFaild = "Successful";
                DOC.color = "success";
            }
            else
            {
                DOC.sucessOrFaild = "Fail";
                DOC.color = "danger";
            }

           
            return View(DOC);
        }

    }
}
