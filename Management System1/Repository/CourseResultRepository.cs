using Management_System1.Data;
using Management_System1.Models;
using Microsoft.EntityFrameworkCore;

namespace Management_System1.Repository
{
    public class CourseResultRepository:ICourseResultRepository
    {

        ApplicationDBContext Context = new ApplicationDBContext();
        public List<CourseResult> GetAll()
        {

            return Context.CrsResults.ToList();

        }

        public CourseResult GetByID(int id)
        {
            return Context.CrsResults.FirstOrDefault(d => d.Trainee_Id == id);
        }

    }
}
