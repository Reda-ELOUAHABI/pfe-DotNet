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
        public int StageId { get; set; }


        [Display(Name = "Encadrant Externe")]
        public string EncadrantExterne { get; set; }

        [Display(Name = "Organisme d'Aceuil")]
        public string OrganismeAceuil { get; set; }

        [Display(Name = "Pays de stage")]
        public string PaysStage { get; set; }
        public string Sujet { get; set; }

        [Display(Name = "ville de stage")]
        public string VilleStage { get; set; }

        public int EtatStage { get; set; }

        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Display(Name = "Date debut")]
        public DateTime DateDebut { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date fin")]
        public DateTime DateFin { get; set; }

        [Display(Name = "Encadrant interne ")]

        public int EnseignantId { get; set; }
        public Enseignant EncadrantInterne { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
