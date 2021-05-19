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
        public string cne { get; set; }
        public string cin { get; set; }

        public string nom { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public string prenom { get; set; }
        public DateTime dateNaissance { get; set; }
        public string genre { get; set; }
        public string matricule { get; set; }
        public string telephone { get; set; }
        public Filiere filiere { get; set; }
        public string promotion { get; set; }
        public Stage stage { get; set; }




        /*     public Student(string cne,string cin,string nom,DateTime d)
             {
                 cne = cne;
                 cin = cin;
                 nom = nom;
                 dateNaissance = d;
             } */


    }
}

