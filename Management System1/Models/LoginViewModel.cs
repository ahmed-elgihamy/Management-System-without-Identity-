using System.ComponentModel.DataAnnotations;

namespace Management_System1.Models
{
    public class LoginViewModel
    {

        [Required]
        public string Name { get; set; }
     

        [DataType(DataType.Password)]
        public string Passward { get; set; }
    }
}
