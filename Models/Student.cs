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
        public int StudentId { get; set; }
        public string Cne { get; set; }
        public string Cin { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Prenom { get; set; }

        public string Email { get; set; }

        public int FiliereId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissance { get; set; }
        public string Genre { get; set; }
        public string Matricule { get; set; }
        public string Telephone { get; set; }
        public Filiere Filiere { get; set; }
        public string Promotion { get; set; }
        public int? StageId { get; set; }
        public Stage Stage { get; set; }




        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }


        /*     public Student(string cne,string cin,string nom,DateTime d)
             {
                 cne = cne;
                 cin = cin;
                 nom = nom;
                 dateNaissance = d;
             } */


    }
}

