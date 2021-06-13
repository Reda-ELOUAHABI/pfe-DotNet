using pfe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pfe.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.



            /*  var s = new Student("12345", "Alexander", "Hamza", DateTime.Parse("2010-09-01")); 




              context.Students.Add(s);
              context.SaveChanges();   */
 /*           var students = new Student[]
            {
new Student{Nom="Carson",Prenom="Alexander" ,DateNaissance=DateTime.Parse("2005-09-1"),StageId=1},
new Student{Nom="Meredith" ,Prenom="Alonso", DateNaissance=DateTime.Parse("2002-09-01"),StageId=2},
new Student{Nom="Arturo", Prenom="Anand" ,DateNaissance=DateTime.Parse("2003-09-01"),StageId=3},
new Student{Nom="Gytis", Prenom="Barzdukas" , DateNaissance=DateTime.Parse("2002-09-01")}
            };

            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();


            var Filieres = new Filiere[]
               {
                   new Filiere { FiliereId = 1050, NomFiliere = "Informatique", StudentID = 1},
                   new Filiere { FiliereId = 4022, NomFiliere = "industriel", StudentID = 2 },
                   new Filiere { FiliereId = 4041, NomFiliere = "mecanique", StudentID = 1},
                   new Filiere { FiliereId = 1045, NomFiliere = "MIS", StudentID = 2 },
                   new Filiere { FiliereId = 3141, NomFiliere = "electrique",StudentID = 2 },
                   new Filiere { FiliereId = 2021, NomFiliere = "RT", StudentID = 3 },
                   new Filiere { FiliereId = 2042, NomFiliere = "Civil", StudentID = 3 }
               };

            foreach (Filiere c in Filieres)
            {
                context.Filiere.Add(c);
            }

            context.SaveChanges();

            var stages = new Stage[]
{

new Stage { Sujet = "1050", StageId=1   },
new Stage { StageId = 2, Sujet = "1045",   },
new Stage { StageId = 3, Sujet = "3141",   },
new Stage { StageId = 4, Sujet = "1045" },
new Stage { StageId = 5, Sujet = "3141",   },
};


            foreach (Stage s in stages)
            {
                context.Stage.Add(s);
            } */
            context.SaveChanges();




        }
    }
}
