using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS02.Models
{
    public class Specialty
    {
        [Key]
        public int IdSpecialty { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30)]
        public string name { get; set; }

        #region Relaciones de la clase
        public ICollection<trainingProgram> trainingProgram { get; set; }
        #endregion        
    }
}