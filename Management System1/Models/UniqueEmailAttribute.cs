using Management_System1.Data;
using System.ComponentModel.DataAnnotations;

namespace Management_System1.Models
{
    public class UniqueEmailAttribute: ValidationAttribute
    {
        public string msgError { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
            var email = value.ToString();
            ApplicationDBContext db = new ApplicationDBContext();

              Trainee tr = (Trainee) validationContext.ObjectInstance;
              var stdEmail = db.Trainees.FirstOrDefault(d => d.Email == email && d.Id !=tr.Id);

             
                if (stdEmail != null)
                {
                return new ValidationResult(msgError);

                }
            return ValidationResult.Success;
        }
    }
}
