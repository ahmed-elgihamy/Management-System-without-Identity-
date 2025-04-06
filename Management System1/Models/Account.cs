using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Management_System1.Models
{
    [Table("Account")]
    public class Account
    {


    
            [Key]
            public int Id { get; set; }

            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }
     
    }
}
