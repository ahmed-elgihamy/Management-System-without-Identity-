using Management_System1.Models;

namespace Management_System1.Controllers
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        void Delete(int id);
        void Edit(int id, Department trainee);
        void Add(Department trainee);
        Department GetByID(int? id);
    }
}