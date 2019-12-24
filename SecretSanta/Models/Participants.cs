using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Models
{
    public class Participants
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Name is a required field")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="Email is a required field")]
        public string Email { get; set; }

       //public List<Participants>  participantsInfo { get; set; }
      
        public override string ToString()
        {
            return Name;
        }

      /*  public void Validate()
        {
            ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, context, results, true);

            if (isValid == false)
            {
                StringBuilder sbrErrors = new StringBuilder();
                foreach (var validationResult in results)
                {
                    sbrErrors.AppendLine(validationResult.ErrorMessage);
                }
                throw new ValidationException(sbrErrors.ToString());
            }
        }*/

    }
}
