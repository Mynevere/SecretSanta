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

      
        public override string ToString()
        {
            return Name;
        }
    }
}
