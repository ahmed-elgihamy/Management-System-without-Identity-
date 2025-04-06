using Management_System1.Models;

namespace Management_System1.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetByID(int? id);
    }
}
