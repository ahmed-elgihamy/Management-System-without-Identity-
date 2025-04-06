using Management_System1.Models;

namespace Management_System1.Repository
{
    public interface IStudentRepository
    {

        Guid Id { get; set; }
        List<Trainee> GetAll();
        void Delete(int id);
        void Edit(int id, Trainee trainee);
        void Add(Trainee trainee);
        Trainee GetByID(int? id);
    }
}
