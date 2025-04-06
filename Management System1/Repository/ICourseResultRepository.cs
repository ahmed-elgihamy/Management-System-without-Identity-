using Management_System1.Models;

namespace Management_System1.Repository
{
    public interface ICourseResultRepository
    {
        CourseResult GetByID(int id);
         List<CourseResult> GetAll() ;
    }
}
