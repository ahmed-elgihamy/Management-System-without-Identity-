using Management_System1.Models;

namespace Management_System1.Repository
{
    public interface IUserRepository
    {


        Role GetRole(string n);
       void  AddUser(User s);
        void SaveChanged();
        List<User> getAllUser();
        User UserAndRoles(int id);
        List<Role> AllRoles();
        Role GetRoleById(int id);
    }
}
