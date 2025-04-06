using Management_System1.Data;
using Management_System1.Models;

namespace Management_System1.Repository
{
    public class CourseRepository:ICourseRepository
    {
        ApplicationDBContext Context;

        public CourseRepository( ApplicationDBContext _dBContext)
        {
            Context = _dBContext;
        }
        public List<Course> GetAll()
        {

            return Context.Courses.ToList();
        
        }

        public Course GetByID(int? id)
        {
            return Context.Courses.FirstOrDefault(d => d.Id == id);
        }



      
    }
}
