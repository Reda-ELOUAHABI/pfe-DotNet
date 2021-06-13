using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pfe.Models
{
    public class Enseignant
    {
        [Key]
        public int EnseignantId { get; set; }

        public string Cin { get; set; }


        [RegularExpression("[A-Z].*")]
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public ICollection<Stage> Stages { get; set; }
    }
}
