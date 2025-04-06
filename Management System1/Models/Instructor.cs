using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Management_System1.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Imag { get; set; }

        public decimal Salary { get; set; }

        public string Address { get; set; }

        // Foreign keys
       public int Dept_Id { get; set; }
        public int Crs_Id { get; set; }

        // Navigation properties
        [ForeignKey("Dept_Id")]
        public virtual Department Department { get; set; }

        [ForeignKey("Crs_Id")]
        public virtual Course Course { get; set; }
    }
}
