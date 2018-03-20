using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS02.Models
{
    public class trimester
    {
        [Key]
        public int IdTrimester { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(25)]
        public string name { get; set; }

        #region Relaciones de la clase
        public virtual ICollection<group> group { get; set; }
        #endregion
    }
}