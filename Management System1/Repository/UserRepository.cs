using Management_System1.Data;
using Management_System1.Models;
using Microsoft.EntityFrameworkCore;

namespace Management_System1.Repository
{
    public class UserRepository: IUserRepository
    {
        ApplicationDBContext Context;

        public UserRepository(ApplicationDBContext _dBContext)
        {
            Context = _dBContext;
        }


        public Role GetRole(string n)
        {
            return Context.roles.FirstOrDefault(d => d.Name == n);
        }

        public Role GetRoleById(int id)
        {
            return Context.roles.FirstOrDefault(d => d.Id == id);
        }
        public List<User> getAllUser()
        {
            return Context.users.ToList();
        }

        public void AddUser(User s)
        {
            Context.users.Add(s);
        }

        public User UserAndRoles(int id)
        {
            return Context.users.Include(s => s.Roles).FirstOrDefault(d => d.Id ==id);
        }

        public List<Role> AllRoles()
        {
            return Context.roles.ToList();
        }
        public void SaveChanged()
        {
            Context.SaveChanges();
        }


        //public List<Role> rolesInUser(int id)
        //{
        //    return Context.users.inc
        //}
    }
}
