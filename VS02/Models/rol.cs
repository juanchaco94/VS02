using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS02.Models
{
    public class rol
    {
        [Key]
        public int IdRol { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(30)]
        public string description { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool status { get; set; }


        #region relaciones de la clase
        public virtual ICollection<person> person { get; set; }
        #endregion
    }
}