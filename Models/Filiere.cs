using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pfe.Models
{

    public class Filiere
    {

        [Key]
        public int FiliereId { get; set; }

        public string NomFiliere { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}

