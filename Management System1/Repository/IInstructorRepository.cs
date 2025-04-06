using Management_System1.Models;

namespace Management_System1.Repository
{
    public interface IInstructorRepository
    {
        List<Instructor> GetAll();
        Instructor GetByID(int? id);
    }
}
