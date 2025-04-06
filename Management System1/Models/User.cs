using System.ComponentModel.DataAnnotations;

namespace Management_System1.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual List<Role> Roles { get; set; } = new List<Role>();

    }
}
