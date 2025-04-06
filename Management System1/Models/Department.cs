using System.ComponentModel.DataAnnotations;

namespace Management_System1.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

      
     //   [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string? Manager { get; set; }

       
          public virtual ICollection<Instructor> ?Instructors { get; set; }
        public virtual ICollection<Trainee>? Trainees { get; set; }
  
    }
}
