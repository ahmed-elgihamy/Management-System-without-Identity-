using System.ComponentModel.DataAnnotations;

namespace Management_System1.Models
{
    public class Login
    {

        [Required]
        public string Name { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Passward { get; set; }
    }
}
