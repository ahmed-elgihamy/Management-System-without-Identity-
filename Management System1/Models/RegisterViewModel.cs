using System.ComponentModel.DataAnnotations;

namespace Management_System1.Models
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string CPassword { get; set; }
        public string Email { get; set; }
    }
}
