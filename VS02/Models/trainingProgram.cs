using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS02.Models
{
    public class trainingProgram
    {
        [Key]
        public int IdTrainingProgram { get; set; }
        
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(100)]
        public string  name { get; set; }

        [Display(Name = "Acronimo")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(7)]
        public string acronym { get; set; }

        [Display(Name = "Especialidad del programa")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdSpecialty { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool status { get; set; }

        #region Relaciones de la clase
        public virtual Specialty Specialty { get; set; }
        public ICollection<data> data { get; set; }
        #endregion
    }
}