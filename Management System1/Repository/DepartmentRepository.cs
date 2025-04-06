using Management_System1.Controllers;
using Management_System1.Data;
using Management_System1.Models;

namespace Management_System1.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ApplicationDBContext Context = new ApplicationDBContext();
        public List<Department> GetAll()
        {
           var d = Context.Departments.ToList();
            return d;
        }

        public Department GetByID(int? id)
        {
            return Context.Departments.FirstOrDefault(d => d.Id == id);
        }



        public void Add(Department dept)
        {
            Context.Departments.Add(dept);
            Context.SaveChanges();
        }

        public void Edit(int id, Department Dept)
        {
            var oldDept = Context.Departments.FirstOrDefault(d => d.Id == id);
            oldDept.Name = Dept.Name;
            oldDept.Manager = Dept.Manager;


            Context.SaveChanges();
        }


        public void Delete(int id)
        {
            var  dept = Context.Departments.FirstOrDefault(d => d.Id == id);

            Context.Departments.Remove(dept);
            Context.SaveChanges();
        }

 
    }
}
