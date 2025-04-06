using Management_System1.Models;
using System.ComponentModel.DataAnnotations;

namespace Management_System1.ViewModels
{
    public class DataShowTrainee
    {
        public List <Trainee> trainees { get; set; }
        public List <Department> Depts { get; set; }
       public List <Course> Courses { get; set; }
        public List <CourseResult> CoursesR { get; set; }
    }
}
