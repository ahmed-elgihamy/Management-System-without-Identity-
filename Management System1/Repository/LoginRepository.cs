using Management_System1.Data;
using Management_System1.Models;
using Microsoft.EntityFrameworkCore;

namespace Management_System1.Repository
{
    public class LoginRepository:ILoginRepository
    {

        ApplicationDBContext context;
        
        public LoginRepository(ApplicationDBContext _dBContext)
        {

            context = _dBContext;
            
        }

        public User Exist(string name , string pass)
        {
        //  return  context.users.Include(d=>d.Roles).FirstOrDefault(d => d.Name == name && d.Password == pass);
          return  context.users.FirstOrDefault(d => d.Name == name && d.Password == pass);
        }
    }
}
