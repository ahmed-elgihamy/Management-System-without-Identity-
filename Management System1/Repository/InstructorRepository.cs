using Management_System1.Data;
using Management_System1.Models;
using Microsoft.EntityFrameworkCore;

namespace Management_System1.Repository
{
    public class InstructorRepository:IInstructorRepository
    {

        ApplicationDBContext Context = new ApplicationDBContext();
        public List<Instructor> GetAll()
        {

            return Context.Instructors.Include(d=>d.Course ).Include(d=>d.Department).ToList();

        }

        public Instructor GetByID(int? id)
        {
            return Context.Instructors.FirstOrDefault(d => d.Id == id);
        }

    }
}
