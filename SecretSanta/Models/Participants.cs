using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Models
{
    public class Participants
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

       //public List<Participants>  participantsInfo { get; set; }
      
        public override string ToString()
        {
            return Name;
        }

    }
}
