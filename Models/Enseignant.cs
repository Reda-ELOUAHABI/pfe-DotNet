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
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public ICollection<Stage> stages { get; set; }
    }
}
