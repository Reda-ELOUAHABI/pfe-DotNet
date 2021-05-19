using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pfe.Models
{
    public class Stage
    {
        [Key]
        public int stageId { get; set; }

        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public string encadrantExterne { get; set; }
        public string organismeAceuil { get; set; }
        public string paysStage { get; set; }
        public string sujet { get; set; }
        public string villeStage { get; set; }

        public ICollection<Enseignant> enseignants { get; set; }
        public ICollection<Student> etudiants { get; set; }
    }
}
