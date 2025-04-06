using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Management_System1.Models
{
    public class Trainee
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3,ErrorMessage ="**Name must be greater than 2 letter")]
        [MaxLength(20 ,ErrorMessage ="**Name must be less than 20 letter")]

   
        public string Name { get; set; }
        [Required]
        [Range(20,50 ,ErrorMessage ="**Age must be between 20 to 50")]
        public int Age { get; set; }
        public string Imag { get; set; }

        [RegularExpression(@"(Alex|Cairo)" ,ErrorMessage ="**Address Must be (Alex or Cario)")]
        public string Address { get; set; }
        [UniqueEmail(msgError = "**The Email already Exists")]
        //[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
  //  ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
     //   [Display(Name="Department ID")]

        public int Dept_Id { get; set; }
       [Required,StringLength(20,MinimumLength= 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [NotMapped]
        [DataType(DataType.Password)]
        public string CPassword { get; set; }


        [ForeignKey("Dept_Id")]
        public virtual Department? Department { get; set; }

        public virtual ICollection<CourseResult> ? CrsResults { get; set; }
    }
}
