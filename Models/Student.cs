using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pfe.Models
{
    public class Student
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string cne { get; set; }
        [Required]
        public string cin { get; set; }
        [Required]
        public string nom { get; set; }
        [Required]
        public string prenom { get; set; }

        [Required]
        public string email { get; set; }
        [Required]
        public DateTime dateNaissance { get; set; }
        [Required]
        public string genre { get; set; }

        /*        [Required]
                public string matricule { get; set; }*/

        [Required]
        public string telephone { get; set; }
        [Required]
        public string promotion { get; set; }
        [Required]
        public Filiere filiere { get; set; }

#nullable enable
        public Stage? stage { get; set; }




        /*     public Student(string cne,string cin,string nom,DateTime d)
             {
                 cne = cne;
                 cin = cin;
                 nom = nom;
                 dateNaissance = d;
             } */


    }
}

