using Management_System1.Models;

namespace Management_System1.Repository
{
    public interface ILoginRepository
    {
        User Exist(string name, string pass);
    }
}
