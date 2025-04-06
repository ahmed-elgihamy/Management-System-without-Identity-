using Management_System1.Data;
using Management_System1.Models;
using Microsoft.EntityFrameworkCore;

namespace Management_System1.Repository
{
    public class StudentRepository: IStudentRepository
    {
        ApplicationDBContext Context;//= new ApplicationDBContext();

        public Guid Id { get; set; }
        public StudentRepository(ApplicationDBContext _context)
        {
            Context = _context;
            Id = Guid.NewGuid();
        }
        
        public  List<Trainee> GetAll()
        {

           return Context.Trainees.Include(d => d.Department).ToList();
         //  return Context.Trainees.ToList();
        }

        public Trainee GetByID(int ?id)
        {
            return Context.Trainees.FirstOrDefault(d => d.Id == id);
        }



        public void Add(Trainee trainee)
        {
            Context.Trainees.Add(trainee);
            Context.SaveChanges();
        }

        public void Edit (int id , Trainee trainee)
        {
            var oldstd = Context.Trainees.FirstOrDefault(d => d.Id == id);

            oldstd.Name = trainee.Name;
            oldstd.Email = trainee.Email;
            oldstd.Age = trainee.Age;
            oldstd.Imag = trainee.Imag;
            oldstd.Dept_Id = trainee.Dept_Id;
            oldstd.Address = trainee.Address;
            oldstd.Password = trainee.Password;
            oldstd.CPassword = trainee.CPassword;
            Context.SaveChanges();
        }


        public void Delete(int id)
        {
            var oldstd = Context.Trainees.FirstOrDefault(d => d.Id == id);

            Context.Trainees.Remove(oldstd);
            Context.SaveChanges();
        }
    }
}
