using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Management_System1.Models
{
    public class CourseResult
    {
        [Key]
        public int Id { get; set; }

        public int Degree { get; set; }

        public int Crs_Id { get; set; }
        public int Trainee_Id { get; set; }

  
        [ForeignKey("Crs_Id")]
        public virtual Course Course { get; set; }

        [ForeignKey("Trainee_Id")]
        public virtual Trainee Trainee { get; set; }
    }
}
