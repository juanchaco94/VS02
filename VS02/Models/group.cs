using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS02.Models
{
    public class group
    {
        [Key]
        public int IdGroup { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(25)]
        public string name { get; set; }

        [Display(Name = "Número de la ficha")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdData { get; set; }

        [Display(Name = "Ambiente")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdAmbient { get; set; }

        [Display(Name = "Trimestre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdTrimester { get; set; }

        #region Relaciones de la clase
        public virtual data data { get; set; }
        public virtual ambient ambient { get; set; }
        public virtual trimester trimester { get; set; }
        #endregion
    }
}