using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pfe.Models
{
    public enum Fil
    { 
        INFORMATIQUE,INDUSTRIEL
    }
    public class Filiere
    {

        [Key]
        public int idFiliere { get; set; }
        [Required]
        public Fil nomFiliere { get; set; }

        public ICollection<Student> students { get; set; }
    }
}

