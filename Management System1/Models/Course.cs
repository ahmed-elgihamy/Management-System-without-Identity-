using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Management_System1.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Degree { get; set; }
        public int MinDegree { get; set; }

        // Navigation Properties
        public virtual ICollection<Instructor> Instructors { get; set; }
       public virtual ICollection<CourseResult> CrsResults { get; set; }
    }
}
